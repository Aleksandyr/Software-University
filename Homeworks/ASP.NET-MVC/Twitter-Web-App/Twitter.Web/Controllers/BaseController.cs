namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data.UnitOfWork;
    using Twitter.Models;

    public abstract class BaseController : Controller
    {
        private ITwitterData data;
        private User userProfile;

        public BaseController(ITwitterData data)
        {
            this.TwitterData = data;
        }

        public BaseController(ITwitterData data, User userProfile)
            :this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ITwitterData TwitterData { get; private set; }
        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.TwitterData.Users.All().FirstOrDefault(x => x.UserName == username);
                this.UserProfile = user;
            }
            
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
