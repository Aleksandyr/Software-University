using System;
using System.Linq.Expressions;
using Messages.Data.Models;

namespace Messages.RestServices.Models.ViewModels
{
    public class ChannelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Channel, ChannelViewModel>> Create
        {
            get
            {
                return c => new ChannelViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                };
            }
        } 
    }
}