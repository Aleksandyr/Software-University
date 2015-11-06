using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace Snippets.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using AutoMapper;

    using Snippets.Models;
    
    using Common;
    using Data;
    using ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(ISnippetsData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var snippets = this.Data.Snippets
                .All()
                .Include(x => x.Labels)
                .OrderByDescending(x => x.CreationTime)
                .Take(GlobalConstants.HomePageNumber);

            var comments = this.Data.Comments.All()
                .OrderByDescending(x => x.CreationTime)
                .Take(GlobalConstants.HomePageNumber);

            var labels = Data.Labels
                .All()
                .OrderByDescending(l => l.Snippets.Count)
                .Take(GlobalConstants.HomePageNumber);

            var model = new HomePageViewModel()
            {
                Snippets = Mapper.Map<IEnumerable<SnippetViewModel>>(snippets),
                Comments = Mapper.Map<IEnumerable<CommentViewModel>>(comments),
                Labels = Mapper.Map<IEnumerable<HomePageLabelViewModel>>(labels)
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}