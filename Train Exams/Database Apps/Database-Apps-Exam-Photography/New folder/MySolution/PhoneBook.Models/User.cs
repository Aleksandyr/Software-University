using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class User
    {
        private ICollection<User> recipientUsers;
        private ICollection<User> senderUsers;
        private ICollection<Channel> chanels;

         public User()
        {
            this.Chanels = new HashSet<Channel>();
            this.SenderUsers = new HashSet<User>();
            this.RecipientUsers = new HashSet<User>();
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<User> RecipientUsers
        {
            get { return this.recipientUsers; }
            set { this.recipientUsers = value; }
        }

        public virtual ICollection<User> SenderUsers
        {
            get { return this.senderUsers; }
            set { this.senderUsers = value; }
        }

        public virtual ICollection<Channel> Chanels
        {
            get { return this.chanels; }
            set { this.chanels = value; }
        }
    }
}
