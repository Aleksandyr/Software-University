using System.ComponentModel.DataAnnotations;

namespace BugTracker.RestServices.Models.BindingModels
{
    public class BugPostBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}