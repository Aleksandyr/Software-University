using System.Collections.Generic;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Users
{
    class Administrator : IAdministrator
    {
        public Administrator(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IList<IQuestion> Questions { get; private set; }
    }
}
