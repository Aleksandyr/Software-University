﻿namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Infrastructure;
    using Models;

    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;

            viewResult.AppendFormat("User {0} registered successfully.", user.Username).AppendLine();
        }
    }
}