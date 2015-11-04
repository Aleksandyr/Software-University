namespace Bookmarks.Web.Controllers
{
    using Bookmars.Data;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        protected BaseController(IBookmarksData data)
        {
            this.Data = data;
        }

        protected IBookmarksData Data { get; private set; }
    }
}