namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    
    using Bookmarks.Web.ViewModels;
    using Bookmars.Data;
    using Bookmarks.Common;

    public class HomeController : BaseController
    {
        public HomeController(IBookmarksData data) : base(data)
        {

        }

        public ActionResult Index()
        {
            var bookmarks = this.Data.Bookmarks
                .All()
                .OrderByDescending(x => x.Votes.Count)
                .Take(GlobalConstants.HomePageNumberOfBookmarks)
                .Project()
                .To<BookmarkViewModel>();

            return View(bookmarks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}