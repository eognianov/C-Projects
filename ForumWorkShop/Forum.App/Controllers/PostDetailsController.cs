﻿using Forum.App.Services;
using Forum.App.UserInterface;
using Forum.App.UserInterface.ViewModels;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;


    public class PostDetailsController : IController, IUserRestrictedController
    {
        public bool LoggedInUser { get; set; }

        public int PostId { get; private set; }

        private enum Command
        {
            Back, AddReply
        }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
                case Command.AddReply:
                    return MenuState.AddReplyToPost;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            PostViewModel pvm = PostService.GetPostViewModel(this.PostId);

            return new PostDetailsView(pvm, this.LoggedInUser);
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }
    }
}
