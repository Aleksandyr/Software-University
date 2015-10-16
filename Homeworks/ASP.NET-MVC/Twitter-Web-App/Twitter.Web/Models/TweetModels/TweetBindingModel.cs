using System.ComponentModel.DataAnnotations;

namespace Twitter.Web.Models.TweetModels
{
    public class TweetBindingModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Message { get; set; }
    }
}