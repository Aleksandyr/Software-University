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
using Messages.RestServices.Models;
using Messages.RestServices.Models.BindingModels;
using Messages.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace Messages.RestServices.Controllers
{
    [RoutePrefix("api/channel-messages")]
    public class ChannelMessagesController : ApiController
    {
        private readonly IMessagesData db;

        public ChannelMessagesController() : this(new MessagesData())
        {
        }

        public ChannelMessagesController(IMessagesData data)
        {
            this.db = data;
        }

        // GET: api/channel-messages/channelName
        [HttpGet]
        [Route("{channelName}")]
        public IHttpActionResult GetChannelMessages(string channelName, [FromUri] string limit = null)
        {
            var channel = db.Channels.All().FirstOrDefault(c => c.Name == channelName);
            if (channel == null)
            {
                return this.NotFound();
            }

            var messages = db.ChannelMessages.All()
                .Where(m => m.Channel.Id == channel.Id)
                .OrderByDescending(m => m.DateSent)
                .ThenByDescending(m => m.Id);

            if (limit != null)
            {
                int limitCount = 0;
                int.TryParse(limit, out limitCount);
                if (limitCount >= 1 && limitCount <= 1000)
                {
                    messages = (IOrderedQueryable<ChannelMessage>) messages.Take(limitCount);
                }
                else
                {
                    return this.BadRequest("Limit should be integer in range [1..1000].");
                }
            }

            return this.Ok(
                messages.Select(m => new MessagesViewModel()
                {
                    Id = m.Id,
                    Text = m.Text,
                    DateSent = m.DateSent,
                    Sender = (m.User != null) ? m.User.UserName : null
                }));
        }

        // POST: api/ChannelMessages/{channelName}
        [Route("{channelName}")]
        [HttpPost]
        [ResponseType(typeof (ChannelMessage))]
        public IHttpActionResult SentdChannelMessage([FromUri] string channelName,
            [FromBody] ChannelMessageBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("Missing message date.");
            }

            var channel = db.Channels.All().FirstOrDefault(c => c.Name == channelName);
            if (channel == null)
            {
                return this.NotFound();
            }

            var currentUserId = User.Identity.GetUserId();
            var currentUser = this.db.Users.Find(currentUserId);

            var channelMessage = new ChannelMessage()
            {
                Text = model.Text,
                Channel = channel,
                DateSent = DateTime.Now,
                User = currentUser
            };

            db.ChannelMessages.Add(channelMessage);
            db.SaveChanges();

            if (currentUser == null)
            {
                return Ok(new
                {
                    channelMessage.Id,
                    Message = "Anonymous message sent to channel " + channelName + "."
                });
            }

            return Ok(new
            {
                channelMessage.Id,
                Sender = channelMessage.User.UserName,
                Message = "Anonymous message sent to channel " + channelName + "."
            });
        }
    }
}