using Bookmarks.Common;
using System.ComponentModel.DataAnnotations;
namespace Bookmarks.Web.InputModels
{
    public class BookmarkInputModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        [StringLength(200, ErrorMessage = "The {0} should be between {2} to {1}")]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}