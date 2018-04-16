namespace Forum.App.Models.Commands
{
    using Contracts;

    public class LogOutMenuCommand : BaseMenuCommand
    {
        public LogOutMenuCommand(IMenuFactory menuFactory)
            : base(menuFactory)
        {
        }
    }
}
