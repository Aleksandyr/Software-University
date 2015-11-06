using System;
using AutoMapper;
using Snippets.Common.Mappings;
using Snippets.Models;

namespace Snippets.Web.ViewModels
{
    public class DetailsCommentViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, DetailsCommentViewModel>()
                .ForMember(x => x.Author, cnf => cnf.MapFrom(m => m.Author.UserName));
        }
    }
}