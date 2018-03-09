using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.Data;
using Forum.Models;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            var validateUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            var validatePassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;
            if (!validateUsername || !validatePassword)
            {
                return SignUpStatus.DetailsError;
            }

            var forumData = new ForumData();

            bool userAlreadyExists = forumData.Users.Any(u => u.UserName == username);
            if (!userAlreadyExists)
            {
                //creat new
                var id = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
                var user = new User(id, username, password, new List<int>());
                forumData.Users.Add(user);
                forumData.SaveChanges();
                return SignUpStatus.Success;
            }

            return SignUpStatus.UsernameTakenError;
        }

        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();
            bool userExists = forumData.Users.Any(u => u.UserName == username && u.Password == password);
            return userExists;
        }
    }
}
