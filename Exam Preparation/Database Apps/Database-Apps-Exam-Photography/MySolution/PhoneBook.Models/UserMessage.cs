using System;
using System.Collections;
using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        public int SenderId { get; set; }

        public virtual User Sender { get; set; }
    }
}
