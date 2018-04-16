using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<int> PostIds { get; set; }

        public User(int id, string userName, string password, ICollection<int> postIds)
        {
            Id = id;
            UserName = userName;
            Password = password;
            PostIds =new List<int>(postIds);
        }
    }
}
