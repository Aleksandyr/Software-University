using System;
using System.Linq;
using System.Net;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Snippets.Models;
using Snippets.Web.BindingModels;

namespace Snippets.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Snippets.Data;
    using Snippets.Web.ViewModels;

    public class SnippetsController : BaseController
    {

        public SnippetsController(ISnippetsData data)
            : base(data)
        {
        }


        public ActionResult AllSnippets()
        {
            var snippets = Data.Snippets
                .All()
                .OrderByDescending(x => x.CreationTime)
                .Project()
                .To<SnippetViewModel>();

            return this.View(snippets);
        }

        // GET: Snippets
        public ActionResult Details(int id)
        {
            var snippet = Data.Snippets
                .All()
                .FirstOrDefault(x => x.Id == id);
                
                var snippetViewModel = Mapper.Map<SnippetDetailsViewModel>(snippet);

            return this.View(snippetViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int commentId)
        {
            var comment = Data.Comments
                .All()
                .FirstOrDefault(x => x.Id == commentId);

            if (comment != null && comment.AuthorId == User.Identity.GetUserId())
            {
                Data.Comments.Delete(comment);
                Data.SaveChanges();

                return this.Content(string.Empty);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Can not delete the comment!");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddComment(CommentBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.AuthorId = this.User.Identity.GetUserId();
                model.CreationTime = DateTime.Now;
                var comment = Mapper.Map<Comment>(model);
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentDb = Data.Comments
                    .All()
                    .Where(x => x.Id == comment.Id)
                    .Project()
                    .To<DetailsCommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/DetailsCommentViewModel", commentDb);
            }

            return this.Json("Error");
        }
    }
}