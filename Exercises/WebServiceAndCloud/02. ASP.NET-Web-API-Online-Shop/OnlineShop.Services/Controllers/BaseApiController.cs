using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OnlineShop.Data;

namespace OnlineShop.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new OnlineShopContext())
        {
            
        }
        public BaseApiController(OnlineShopContext data)
        {
            this.Data = data;
        }

        public OnlineShopContext Data { get; set; }
    }
}