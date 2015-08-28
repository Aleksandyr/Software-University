using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookShop.Data;

namespace BookShopWebApp.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private BookShopEntities db = new BookShopEntities();

        [Route("{username}/purchase")]
        public IHttpActionResult getPurchasesForUser(string username)
        {
            return this.Ok();
        }
    }
}
