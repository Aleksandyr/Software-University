using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snippets.Data;

namespace Snippets.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ISnippetsData data)
        {
            this.Data = data;
        }

        protected ISnippetsData Data { get; private set; }
    }
}