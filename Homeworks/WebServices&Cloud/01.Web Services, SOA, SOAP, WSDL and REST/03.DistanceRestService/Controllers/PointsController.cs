using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _03.DistanceRestService.Controllers
{
    public class PointsController : ApiController
    {
        public IHttpActionResult GetDistance(int startX, int startY, int endX, int endY)
        {
            double deltaX = startX - endX;
            double deltaY = startY - endY;

            var distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return this.Ok(distance);
        }
    }
}
