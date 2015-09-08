using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication.ExtendedProtection;
using System.Web.Http;
using System.Web.Http.Description;
using Messages.Data;
using Messages.Data.Models;
using Messages.Data.UnitOfWork;
using Messages.RestServices.Models;
using Messages.RestServices.Models.ViewModels;

namespace Messages.RestServices.Controllers
{
    public class ChannelsController : ApiController
    {
        private readonly IMessagesData db;

        public ChannelsController() : this(new MessagesData())
        {
        }

        public ChannelsController(IMessagesData data)
        {
            this.db = data;
        }

        // GET: api/Channels
        public IHttpActionResult GetChannels()
        {
            var chanels = db.Channels.All().OrderBy(c => c.Name).Select(ChannelViewModel.Create);

            return this.Ok(chanels);
        }

        // GET: api/Channels/5
        [ResponseType(typeof(Channel))]
        public IHttpActionResult GetChannel(int id)
        {
            Channel channel = db.Channels.All().FirstOrDefault(c => c.Id == id);
            if (channel == null)
            {
                return NotFound();
            }

            var channelView = new ChannelViewModel()
            {
                Id = channel.Id,
                Name = channel.Name
            };

            return Ok(channelView);
        }

        // PUT: api/Channels/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult EditChannel([FromUri] int id, [FromBody] ChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing channel data.");
            }

            var channel = db.Channels.Find(id);
            if (channel == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (this.db.Channels.All().Any(c => c.Name == channel.Name && c.Id != id))
            {
                return this.Content(HttpStatusCode.Conflict, new { Message = "Duplicated channel name: " + model.Name });
            }

            channel.Name = model.Name;
            db.Channels.Update(channel);
            db.SaveChanges();

            return this.Ok(new {Message = "Channel #" + channel.Id + " edited successfully."});
        }

        // POST: api/Channels
        [ResponseType(typeof(Channel))]
        public IHttpActionResult CreateChannel([FromBody] ChannelBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing channel data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (this.db.Channels.All().Any(c => c.Name == model.Name))
            {
                return this.Content(HttpStatusCode.Conflict, new {Message = "Duplicated channel name: " + model.Name});
            }
            
            var channel = new Channel()
            {
                Name = model.Name
            };

            db.Channels.Add(channel);
            db.SaveChanges();

            var channelView = new ChannelViewModel()
            {
                Id = channel.Id,
                Name = channel.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = channel.Id }, channelView);
        }

        // DELETE: api/Channels/5
        [ResponseType(typeof(Channel))]
        public IHttpActionResult DeleteChannel(int id)
        {
            Channel channel = db.Channels.Find(id);
            if (channel == null)
            {
                return NotFound();
            }

            if (channel.ChannelMessages.Count > 0)
            {
                return this.Content(HttpStatusCode.Conflict, new { Message = "Cannot delete channel #" + id + " because it is not empty." });
            }

            db.Channels.Remove(channel);
            db.SaveChanges();

            return Ok(new {Message = "Channel #" + id + " deleted."});
        }
    }
}