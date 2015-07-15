using System.Runtime.CompilerServices;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    using System;
    using ConsoleForum.Contracts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            int id = 0;
            var users = this.Forum.Users;
            IUser author = this.Forum.CurrentUser;
            string title = this.Data[1];
            string body = this.Data[2];

            var currUser = this.Forum.CurrentUser;
            this.Forum.Questions.Add(new Question(id + 1, author, title, body));


            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, id));
        }
    }
}
