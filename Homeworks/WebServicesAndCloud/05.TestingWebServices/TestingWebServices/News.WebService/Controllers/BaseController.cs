using System.Web.Http;
using News.Data;
using News.Data.DataLayer;

namespace News.WebService.Controllers
{
    public class BaseController : ApiController
    {
        public BaseController(INewsData data)
        {
            this.Data = data;
        }

        public BaseController()
            :this(new NewsData(new NewsContext()))
        {
            
        }

        public INewsData Data { get; set; }
    }
}
