using System.Collections.Generic;
using MishMash.ViewModels.Channels;

namespace MishMash.ViewModels.Home
{
    public class LoggedInIndexViewModel
    {
        public string UserRole { get; set; }

        public IEnumerable<BaseChannelViewModel> YourChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> SuggestedChannels { get; set; }

        public IEnumerable<BaseChannelViewModel> SeeOtherChannels { get; set; }
    }
}
