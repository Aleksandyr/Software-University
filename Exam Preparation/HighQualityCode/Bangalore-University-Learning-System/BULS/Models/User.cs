namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Utilities;

    public class User
    {
        private string username;
        private string password;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < ValidationConstants.MinUsernameLength)
                {
                    string message = string.Format("The username must be at least {0} symbols long.", ValidationConstants.MinUsernameLength);

                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < ValidationConstants.MinPasswordLength)
                {
                    string message = string.Format("The password must be at least {0} symbols long.", ValidationConstants.MinPasswordLength);

                    throw new ArgumentException(message);
                }
                
                this.password = HashUtilities.HashPassword(value);
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}