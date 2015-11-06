using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snippets.Web.BindingModels
{
    public class CommentBindingModel
    {
        public int SnippetId { get; set; }

        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public string AuthorId { get; set; }
    }
}