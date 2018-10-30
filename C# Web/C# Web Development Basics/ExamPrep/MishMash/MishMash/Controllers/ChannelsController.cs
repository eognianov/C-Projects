using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
