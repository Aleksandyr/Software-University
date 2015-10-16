namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public class PlayController : BaseController
    {
        public PlayController(ITwitterData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View("index");
        }
    }
}
