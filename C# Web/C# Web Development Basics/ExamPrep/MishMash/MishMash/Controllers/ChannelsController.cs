using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MishMash.Models;
using MishMash.ViewModels.Channels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MishMash.Controllers
{
    public class ChannelsController:BaseController
    {
        [HttpGet("/Channels/Details")]
        public IHttpResponse Details(int id)
        {
            if (this.User==null)
            {
                return this.Redirect("/Users/Login");
            }

            var channelViewModel = this.Db.Channels.Where(x => x.Id == id)
                .Select(x => new ChannelViewModel
                {
                    Type = x.Type,
                    Name = x.Name,
                    Description = x.Description,
                    Tags = x.Tags.Select(t=>t.Tag.Name),
                    FollowersCount = x.Followers.Count()
                }).FirstOrDefault();

            return this.View("Channels/Details", channelViewModel);
        }

        [HttpGet("/Channels/Followed")]
        public IHttpResponse Followed()
        {
            if (this.User==null)
            {
                return this.Redirect("/Users/Login");
            }

            var followedChannels = this.Db.Channels.Where(x => x.Followers.Any(f => f.User.Username == this.User.Username)).Select(x =>
                new BaseChannelViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    FollowersCount = x.Followers.Count
                }).ToList();

            var viewModel = new FollowedChannelsViewModel
            {
                FollowedChannels = followedChannels
            };

            return this.View("Channels/Followed", viewModel);
        }

        [HttpGet("/Channels/Follow")]
        public IHttpResponse Follow(int id)
        {
            if (this.User==null)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (!this.Db.UserInChannel.Any(
                x => x.UserId == user.Id && x.ChannelId == id))
            {
                this.Db.UserInChannel.Add(new UserInChannel
                {
                    ChannelId = id,
                    UserId = user.Id,
                });

                this.Db.SaveChanges();
            }

            return this.Redirect("/Channels/Followed");
        }

        [HttpGet("/Channels/Unfollow")]
        public IHttpResponse UnFollow(int id)
        {
            if (this.User==null)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            
            var userInChannel = this.Db.UserInChannel.FirstOrDefault(
                x => x.UserId == user.Id && x.ChannelId == id);
            if (userInChannel != null)
            {
                this.Db.UserInChannel.Remove(userInChannel);
                this.Db.SaveChanges();
            }

            return this.Redirect("/Channels/Followed");
        }
    }
}
