using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace Bookmarks.Web.ViewModels
{
    using Bookmarks.Common.Mappings;
    using Bookmarks.Models;

    public class BookmarkDetailsViewModel : IMapFrom<Bookmark>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        //This automatic get name from category
        public string CategoryName { get; set; }

        public int Votes { get; set; }

        public bool UserHasVoted { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //take user id
            var userId = Thread.CurrentPrincipal.Identity.GetUserId();
            configuration.CreateMap<Bookmark, BookmarkDetailsViewModel>()
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(m => m.Votes.Any() ? m.Votes.Sum(v => v.Value) : 0))
                .ForMember(x => x.UserHasVoted, cnf => cnf.MapFrom(m => m.Votes.Any(v => v.UserId == userId)));
        }
    }


}