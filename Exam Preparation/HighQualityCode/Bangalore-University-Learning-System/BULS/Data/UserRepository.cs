namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Models;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername;

        public UsersRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            return this.usersByUsername.ContainsKey(username) ? this.usersByUsername[username] : null;
        }

        public override void Add(User user)
        {
            this.usersByUsername.Add(user.Username, user);

            base.Add(user);
        }
    }
}
