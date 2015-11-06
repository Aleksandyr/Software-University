using System.Collections.Generic;
using AutoMapper;

namespace Snippets.Web.ViewModels
{
    using Snippets.Common.Mappings;
    using Snippets.Models;

    public class SnippetViewModel : IMapFrom<Snippet>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }
    }
}