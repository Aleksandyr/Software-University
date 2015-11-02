using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Messages.Data.Models;

namespace Messages.RestServices.Models.ViewModels
{
    public class MessagesViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public string Sender { get; set; }

        public static Expression<Func<ChannelMessage, MessagesViewModel>> Create
        {
            get
            {
                return c => new MessagesViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    DateSent = c.DateSent,
                    Sender = (c.User != null) ? c.User.UserName : null,
                };
            }
        } 
    }
}