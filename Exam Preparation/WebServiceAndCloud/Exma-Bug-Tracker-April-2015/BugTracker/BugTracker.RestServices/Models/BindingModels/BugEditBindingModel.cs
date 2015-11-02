using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BugTracker.Data.Models;

namespace BugTracker.RestServices.Models.BindingModels
{
    public class BugEditBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Status? Status { get; set; }
    }
}