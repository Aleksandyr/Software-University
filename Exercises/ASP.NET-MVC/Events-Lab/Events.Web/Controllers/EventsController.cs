using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.Data;
using Events.Web.Extensions;
using Events.Web.Models;
using Microsoft.AspNet.Identity;

namespace Events.Web.Controllers
{
    public class EventsController : BaseController
    {
        // GET: Events
        public ActionResult Create(EventInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var e = new Event()
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Description = model.Description,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };

                this.db.Events.Add(e);
                this.db.SaveChanges();
                this.AddNotification("Event created.", NotificationType.INFO);
                return this.RedirectToAction("My");
            }

            return this.View(model);
        }

        public ActionResult My()
        {
            return View();
        }
    }
}