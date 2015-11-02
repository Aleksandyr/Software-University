using System;

namespace PhoneBook.Models
{
    public class ChannelMessage
    {
        public int  Id { get; set; }
        public string Content { get; set; }
        public DateTime dateTime { get; set; }
        public int ChanelId { get; set; }
        public virtual Channel Channel { get; set; }
        public int UserId { get; set; }
        public virtual User User{ get; set; }
    }
}
