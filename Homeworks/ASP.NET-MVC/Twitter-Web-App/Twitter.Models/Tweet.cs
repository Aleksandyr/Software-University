namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Message { get; set; }

        public virtual User User { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
