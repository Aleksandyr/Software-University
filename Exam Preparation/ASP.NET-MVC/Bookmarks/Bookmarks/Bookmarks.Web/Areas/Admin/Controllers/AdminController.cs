namespace Bookmarks.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using Web.Controllers;
    
    using Bookmars.Data;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        protected AdminController(IBookmarksData data) 
            : base(data)
        {
        }
    }
}