using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class PostViewModel:ContentViewModel,IPostViewModel
    {
        public PostViewModel(string title, string author, string text, IEnumerable<IReplyViewModel> replies) : base(text)
        {
            this.Title = title;
            this.Author = author;
            this.Replies = replies.ToArray();
        }

        public string Title { get; }

        public string Author { get; }

        public IReplyViewModel[] Replies { get; }
    
    }
}
