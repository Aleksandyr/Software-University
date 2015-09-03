using System.Web.Http;
using OnlineShop.Data;
using OnlineShop.Services.Infrastructure;

namespace OnlineShop.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new OnlineShopData(new OnlineShopContext()))
        {
        }

        public BaseApiController(IOnlineShopData data)
        {
            this.Data = data;
        }

        protected IOnlineShopData Data { get; set; }
    }
}