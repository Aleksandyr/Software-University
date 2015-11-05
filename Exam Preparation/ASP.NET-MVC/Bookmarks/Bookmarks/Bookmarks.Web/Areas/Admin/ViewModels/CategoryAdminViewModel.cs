using System.ComponentModel.DataAnnotations;
using Bookmarks.Common.Mappings;
using Bookmarks.Models;

namespace Bookmarks.Web.Areas.Admin.ViewModels
{
    public class CategoryAdminViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}