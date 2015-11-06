using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Snippets.Common.Mappings;
using Snippets.Models;

namespace Snippets.Web.ViewModels
{
    public class SnippetDetailsViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public LanguageViewModel Language { get; set; }

        public string User { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual IEnumerable<LabelViewModel> Labels { get; set; }

        public virtual ICollection<DetailsCommentViewModel> Comments { get; set; }
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Snippet, SnippetDetailsViewModel>()
                .ForMember(x => x.User, cnf => cnf.MapFrom(m => m.User.UserName));
        }
    }
}