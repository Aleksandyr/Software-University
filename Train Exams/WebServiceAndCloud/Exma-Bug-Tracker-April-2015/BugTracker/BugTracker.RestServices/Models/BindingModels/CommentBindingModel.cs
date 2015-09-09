using System.ComponentModel.DataAnnotations;

namespace BugTracker.RestServices.Models.BindingModels
{
    public class CommentBindingModel
    {
        [Required]
        public string Text { get; set; }
    }
}