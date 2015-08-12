using System.Collections.Generic;

namespace Movies.Models
{
    public class Country
    {
        private ICollection<User> users;

        public Country()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
