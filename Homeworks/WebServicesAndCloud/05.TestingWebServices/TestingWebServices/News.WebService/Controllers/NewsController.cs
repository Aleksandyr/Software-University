using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using News.Data;
using News.Data.DataLayer;
using News.Models;
using News.WebService.Models;
using News.WebService.Models.BindingModels;

namespace News.WebService.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : BaseController
    {
        public NewsController()
            :base()
        {
            
        }

        public NewsController(INewsData data)
            :base(data)
        {
            
        }

        // GET: api/News
        public IHttpActionResult GetNews()
        {
            var news =  this.Data.News.All()
                .OrderByDescending(n => n.PublishedData)
                .Select(NewsViewModel.Create);

            return this.Ok(news);
        }

        // PUT: api/News/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNews([FromUri] int id, [FromBody] NewsBindingModel model)
        {
            var @new = this.Data.News.GetById(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            @new.Title = model.Title;
            @new.Content = model.Content;
            @new.PublishedData = DateTime.Now;

            this.Data.SaveChanges();

            var newNews = this.Data.News.GetById(id);
            var newView = new NewsViewModel()
            {
                Title = newNews.Title,
                Content = newNews.Content,
                PublishData = newNews.PublishedData
            };

            return this.Ok(newView);
        }

        // POST: api/News
        [ResponseType(typeof(News.Models.News))]
        public IHttpActionResult PostNewNews([FromBody] NewsBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @new = new News.Models.News()
            {
                Title = model.Title,
                Content = model.Content,
                PublishedData = model.PublishDate
            };


            this.Data.News.Add(@new);
            this.Data.SaveChanges();

            var newView = new NewsViewModel()
            {
                Title = @new.Title,
                Content = @new.Content,
                PublishData = @new.PublishedData
            };

            return this.Created(Uri.UriSchemeHttp, newView);
        }

        // DELETE: api/News/5
        [ResponseType(typeof(News.Models.News))]
        public IHttpActionResult DeleteNew(int id)
        {
            News.Models.News news = this.Data.News.GetById(id);
            if (news == null)
            {
                return NotFound();
            }

            this.Data.News.Delete(news);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}