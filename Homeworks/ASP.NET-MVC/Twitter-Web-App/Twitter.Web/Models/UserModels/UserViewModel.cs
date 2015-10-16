namespace Twitter.Web.Models.UserModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserViewModel
    {
        public string UserName { get; set; }

        public static Expression<Func<User, UserViewModel>> Create
        {
            get
            {
                return r => new UserViewModel()
                {
                    UserName = r.UserName,
                };
            }
        }
    }
}