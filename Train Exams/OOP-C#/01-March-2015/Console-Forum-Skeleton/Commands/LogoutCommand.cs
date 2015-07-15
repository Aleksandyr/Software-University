using System;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class LogoutCommand : AbstractCommand
    {
        private bool isLogout = false;

        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentUser == null)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.NotLogged));
            }

            if (this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.LogoutSuccess));
                this.Forum.CurrentUser = null;
            }
        }
    }
}
