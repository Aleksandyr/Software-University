namespace Bookmarks.Web.Controllers
{
    using Bookmars.Data;
    using System.Web.Mvc;

    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksData data) : base(data)
        {

        }

        // GET: Bookmarks
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}