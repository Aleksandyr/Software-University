using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Snippets.Common.Mappings;
using Snippets.Models;

namespace Snippets.Web.ViewModels
{
    public class HomePageLabelViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SnippetsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Label, HomePageLabelViewModel>()
                .ForMember(x => x.SnippetsCount, cnf => cnf.MapFrom(m => m.Snippets.Count));
        }
    }
}