namespace Bookmarks.Web.Controllers
{
    using Bookmars.Data;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public HomeController(IBookmarksData data) : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
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