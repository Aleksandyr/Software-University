using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BugTracker.Data.Models;
using BugTracker.Data.UnitOfWork;
using BugTracker.RestServices.Models.BindingModels;
using BugTracker.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace BugTracker.RestServices.Controllers
{
    [RoutePrefix("api/bugs")]
    public class BugsController : ApiController
    {
        private readonly IBugTrackerData db;

        public BugsController() : this(new BugTrackerData())
        {
        }

        public BugsController(IBugTrackerData data)
        {
            this.db = data;
        }

        // GET: api/Bugs
        [HttpGet]
        public IQueryable<BugViewModel> GetBugs()
        {
            var bugs = db.Bugs.All()
                .OrderByDescending(b => b.DateCreated)
                .Select(BugViewModel.Create);

            return bugs;
        }

        // GET: api/Bugs/5
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetBugById(int id)
        {
            var bug = db.Bugs.All()
                .Where(c => c.Id == id)
                .Select(BugWithCommentsViewModel.Create)
                .FirstOrDefault();

            if (bug == null)
            {
                return NotFound();
            }

            return Ok(bug);
        }

        // PUT: api/Bugs/5
        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult EditBug(int id, BugEditBindingModel model)
        {
            if (model == null)
            {
                return BadRequest("Missing bug data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bug = db.Bugs.All().FirstOrDefault(c => c.Id == id);
            if (bug == null)
            {
                return NotFound();
            }

            if (model.Title != null)
            {
                bug.Title = model.Title;
            }

            if (model.Description != null)
            {
                bug.Description = model.Description;
            }

            if (model.Status != null)
            {
                bug.Status = model.Status.Value;
            }

            db.Bugs.Update(bug);
            db.SaveChanges();

            return this.Ok(new
            {
                Message = "Message Bug #" + bug.Id + " patched."
            });
        }

        // POST: api/Bugs
        [HttpPost]
        public IHttpActionResult SubmitBug(BugPostBindingModel model)
        {
            if (model == null)
            {
                return BadRequest("Missing bug data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currUserId = User.Identity.GetUserId();
            var currUser = db.Users.Find(currUserId);

            var bug = new Bug()
            {
                Title = model.Title,
                Description = model.Description ?? null,
                Status = Status.Open,
                Author = null,
                DateCreated = DateTime.Now,
                Comments = new List<Comment>()
            };

            if (this.User.Identity.IsAuthenticated)
            {
                var loggedUserId = this.User.Identity.GetUserId();
                var user = db.Users.Find(loggedUserId);
                bug.Author = user;
            }

            db.Bugs.Add(bug);
            db.SaveChanges();

            if (currUser == null)
            {
                return this.Created("http://localhost:5555/api/bugs/" + bug.Id, new
                {
                    Id = bug.Id,
                    Message = "Anonymous bug submitted."
                });
            }

            return this.Created("http://localhost:5555/api/bugs/" + bug.Id, new
            {
                Id = bug.Id,
                Author = bug.Author.UserName,
                Message = "Anonymous bug submitted."
            });
        }

        // DELETE: api/Bugs/5
        [Route("{id}")]
        public IHttpActionResult DeleteBug(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            db.Bugs.Remove(bug);
            db.SaveChanges();

            return Ok(new
            {
                Message = "Bug #" + bug.Id + " deleted."
            });
        }

        [Route("filter")]
        [HttpGet]
        public IEnumerable<BugViewModel> GetBugsByFilte([FromUri] string keyword = null, [FromUri] string statuses = null,
            string author = null)
        {
            IQueryable<BugViewModel> bugs = this.GetBugs();
            if (keyword != null)
            {
               bugs = bugs.Where(b => b.Title.Contains(keyword)); 
            }

            if (statuses != null)
            {
                bugs = bugs.Where(b => statuses.Contains(b.Status));
            }

            if (author != null)
            {
                bugs = bugs.Where(b => b.Author == author);
            }

            return bugs;
        }
    }
}