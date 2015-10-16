namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            : base(data)
        {
        }

        public HomeController()
            :base(new TwitterData())
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