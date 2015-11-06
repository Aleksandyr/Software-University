using System;
using AutoMapper;

namespace Snippets.Web.ViewModels
{
    using Snippets.Common.Mappings;
    using Snippets.Models;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public string Author { get; set; }

        public string Snipped { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Author, cnf => cnf.MapFrom(m => m.Author.UserName))
                .ForMember(x => x.Snipped, cnf => cnf.MapFrom(m => m.Snippet.Title));
        }
    }
}