using Bookmarks.Common.Mappings;
using Bookmarks.Models;

namespace Bookmarks.Web.InputModels
{
    public class CommentInputModel : IMapTo<Comment>
    {
        public int Bookmarkid { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }
    }
}