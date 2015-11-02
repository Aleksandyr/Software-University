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
using Messages.Data;
using Messages.Data.Models;
using Messages.Data.UnitOfWork;
using Messages.RestServices.Models.BindingModels;
using Messages.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace Messages.RestServices.Controllers
{
    [RoutePrefix("api/user")]
    public class UserMessagesController : ApiController
    {
        private readonly IMessagesData db;

        public UserMessagesController() : this(new MessagesData())
        {
        }

        public UserMessagesController(IMessagesData data)
        {
            this.db = data;
        }

        // GET: api/user/personal-messages
        //[Authorize]
        [Route("personal-messages")]
        [Authorize]
        public IHttpActionResult GetUserMessages()
        {
            var currUserId = User.Identity.GetUserId();

            var userMessages = db.UserMessages.All()
                .Where(u => u.RecipientUser.Id == currUserId)
                .OrderByDescending(u => u.DateSent)
                .Select(u => new MessagesViewModel()
                {
                    Id = u.Id,
                    Text = u.Text,
                    DateSent = u.DateSent,
                    Sender = (u.SenderUser != null) ? u.SenderUser.UserName : null
                });

            return this.Ok(userMessages);
        }


        // POST: api/user/personal-messages
        [ResponseType(typeof(UserMessage))]
        [Route("personal-messages")]
        public IHttpActionResult PostUserMessage(UserMessageBindingModel model)
        {
            if (model == null)
            {
                this.BadRequest("Miising message data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recepinet = db.Users.All().FirstOrDefault(u => u.UserName == model.Recipient);
            if (recepinet == null)
            {
                return BadRequest("Recipient user " + model.Recipient + " does not exists.");
            }

            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);


            var userMessage = new UserMessage()
            {
                Text = model.Text,
                DateSent = DateTime.Now,
                SenderUser = currentUser,
                RecipientUser = recepinet
            };

            db.UserMessages.Add(userMessage);
            db.SaveChanges();

            if (userMessage.SenderUser == null)
            {
                return this.Ok(
                    new
                    {
                        userMessage.Id,
                        Message = "Anonymous message sent successfully to user " + recepinet.UserName + "."
                    }
                );
            }

            return this.Ok(
                new
                {
                    userMessage.Id,
                    Sender = userMessage.SenderUser.UserName,
                    Message = "Message sent successfully to user " + recepinet.UserName + "."
                }
            );
        }
    }
}