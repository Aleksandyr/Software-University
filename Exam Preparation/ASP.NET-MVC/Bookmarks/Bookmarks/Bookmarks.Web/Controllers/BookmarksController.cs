namespace Bookmarks.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using Bookmars.Data;
    using Bookmarks.Web.ViewModels;

    using AutoMapper.QueryableExtensions;

    using PagedList;
    using Bookmarks.Common;

    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksData data) : base(data)
        {

        }

        public ActionResult Index(int? page)
        {
            var bookmarks = this.Data.Bookmarks
                .All()
                .OrderByDescending(x => x.Title)
                .Project()
                .To<BookmarkViewModel>()
                .ToPagedList(page ?? GlobalConstants.DefaultStartPage, GlobalConstants.DefaultPageSize);

            return this.View(bookmarks);

        }

        // GET: Bookmarks
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}