using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BugTracker.Data.Models;

namespace BugTracker.RestServices.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> Create
        {
            get
            {
                return c => new CommentViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.DateCreated
                };
            }
        }
    }

    public class CommentWithBugsViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int BugId { get; set; }

        public string BugTitle { get; set; }

        public static Expression<Func<Comment, CommentWithBugsViewModel>> Create
        {
            get
            {
                return c => new CommentWithBugsViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = c.Author == null ? null : c.Author.UserName,
                    DateCreated = c.DateCreated,
                    BugId = c.Bug.Id,
                    BugTitle = c.Bug.Title
                };
            }
        }
    }
}