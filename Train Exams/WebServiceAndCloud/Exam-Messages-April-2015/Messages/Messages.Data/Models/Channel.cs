using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Messages.Data.Models
{
    public class Channel
    {
        private ICollection<ChannelMessage> chanelMessages;

        public Channel()
        {
            this.ChannelMessages = new HashSet<ChannelMessage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ChannelMessage> ChannelMessages
        {
            get { return this.chanelMessages; }
            set { this.chanelMessages = value; }
        }
    }
}
