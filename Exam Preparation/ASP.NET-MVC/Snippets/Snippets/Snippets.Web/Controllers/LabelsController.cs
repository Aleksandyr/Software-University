using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snippets.Data;

namespace Snippets.Web.Controllers
{
    public class LabelsController : BaseController
    {

        public LabelsController(ISnippetsData data)
            : base(data)
        {
        }

        // GET: Labels
        public ActionResult Details(int id)
        {
            return null;
        }
    }
}