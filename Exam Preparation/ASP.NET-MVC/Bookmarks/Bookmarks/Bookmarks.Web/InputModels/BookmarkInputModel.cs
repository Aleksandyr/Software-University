using Bookmarks.Common;
using System.ComponentModel.DataAnnotations;
using Bookmarks.Common.Mappings;
using Bookmarks.Models;

namespace Bookmarks.Web.InputModels
{
    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(200, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(200, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        [Url(ErrorMessage = "The {0} is invalid!")]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}