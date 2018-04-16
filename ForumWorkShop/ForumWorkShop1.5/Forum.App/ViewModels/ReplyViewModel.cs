using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class ReplyViewModel:ContentViewModel,IReplyViewModel
    {
        public ReplyViewModel(string author, string text) : base(text)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
