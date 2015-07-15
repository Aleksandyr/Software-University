using System;
using System.Linq;
using System.Runtime.InteropServices;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Users;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{


    internal class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
           
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            int id = users.First().Id;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);
            string email = users.First().Email;

            if (this.Forum.CurrentUser != null)
            {
                if (!(users.Any(u => u.Username == username && u.Password == password)))
                {
                    throw new CommandException(Messages.InvalidLoginDetails);
                }

                throw new CommandException(Messages.AlreadyLoggedIn);
            }
            
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    id = user.Id;
                    email = user.Email;
                }
            }

            this.Forum.CurrentUser = new User(id, username, password, email);

           
            if (!(users.Any(u => u.Username == username && u.Password == password)))
            {
                this.Forum.CurrentUser = null;
                throw new CommandException(Messages.InvalidLoginDetails);
            }


            if (this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, username));
            }
        }
    }
}
