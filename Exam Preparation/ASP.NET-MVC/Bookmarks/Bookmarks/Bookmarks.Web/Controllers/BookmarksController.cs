using System.Net;
using AutoMapper;
using Bookmarks.Models;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity;

namespace Bookmarks.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using System.Web.Mvc.Expressions;

    using Bookmars.Data;
    using Bookmarks.Web.ViewModels;

    using AutoMapper.QueryableExtensions;

    using PagedList;
    using Bookmarks.Common;
    using Bookmarks.Web.InputModels;

    [Authorize]
    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksData data) : base(data)
        {

        }

        [AllowAnonymous]
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
            var bookmark = Data.Bookmarks
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<BookmarkDetailsViewModel>()
                .FirstOrDefault();

            return View(bookmark);
        }

        public ActionResult Create()
        {
            this.LoadCategories();

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarkInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var bookmark = Mapper.Map<Bookmark>(model);

                this.Data.Bookmarks.Add(bookmark);
                this.Data.SaveChanges();

                return this.RedirectToAction(x => x.Details(bookmark.Id));
            }

            this.LoadCategories();

            //When we return model we will show the errors
            return this.View(model); 
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = this.Data.Categories
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }

        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.UserId = this.User.Identity.GetUserId();
                var comment = Mapper.Map<Comment>(model);
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentDb = this.Data.Comments
                    .All()
                    .Where(x => x.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentDb);
            }

            return this.Json("Error");
        }

        public ActionResult DeleteComment(int commentId)
        {
            var comment = Data.Comments
                .All()
                .FirstOrDefault(x => x.Id == commentId);

            if (comment != null && comment.UserId == User.Identity.GetUserId())
            {
                Data.Comments.Delete(comment);
                Data.SaveChanges();

                return this.Content(string.Empty);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Can not delete the comment!");

        }
    }
}