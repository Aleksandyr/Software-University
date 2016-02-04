namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Infrastructure;
    using Models;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;

            viewResult.AppendFormat("User {0} logged in successfully.", user.Username).AppendLine();
        }
    }
}