using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BugTracker.Data;
using BugTracker.Data.Models;
using BugTracker.Data.UnitOfWork;
using BugTracker.RestServices.Models.BindingModels;
using BugTracker.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace BugTracker.RestServices.Controllers
{
    [RoutePrefix("api")]
    public class CommentsController : ApiController
    {
        private readonly IBugTrackerData db;

        public CommentsController() : this(new BugTrackerData())
        {
        }

        public CommentsController(IBugTrackerData data)
        {
            this.db = data;
        }


        // GET: api/Comments
        [Route("comments")]
        public IQueryable<CommentWithBugsViewModel> GetComments()
        {
            var comments = db.Comments.All()
                .OrderByDescending(c => c.DateCreated)
                .Select(CommentWithBugsViewModel.Create);

            return comments;
        }

        // GET: api/Comments/5
        [Route("bugs/{id}/comments")]
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetCommentByGivenBug(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            var comments = db.Comments.All()
                .Where(c => c.Bug.Id == bug.Id)
                .OrderByDescending(c => c.DateCreated)
                .Select(CommentViewModel.Create);

            return Ok(comments);
        }

        // POST: api/Comments
        [Route("bugs/{id}/comments")]
        [ResponseType(typeof(Comment))]
        [HttpPost]
        public IHttpActionResult AddCommentForGivenBug(int id, CommentBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            var currUserId = User.Identity.GetUserId();
            var currUser = db.Users.Find(currUserId);

            var comment = new Comment()
            {
                Text = model.Text,
                Author = currUser,
                DateCreated = DateTime.Now,
                Bug = bug
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            if (currUser == null)
            {
                return this.Ok(new
                {
                    Id = comment.Id,
                    Message = "Added anonymous comment for bug #" + bug.Id
                });
            }

            return this.Ok(new
            {
                Id = comment.Id,
                Author = comment.Author.UserName,
                Message = "User comment added for bug #" + bug.Id
            });
        }
    }
}