using System;
using System.Collections.Generic;
using System.Globalization;

namespace Snippets.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Snippets.Data.SnippetsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SnippetsDbContext context)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                this.SeedRole(context);
            }

            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }

            if (!context.Labels.Any())
            {
                this.SeedLabels(context);
            }

            if (!context.Languages.Any())
            {
                this.SeedLanguages(context);
            }

            if (!context.Snippets.Any())
            {
                this.SeedSnippets(context);
            }

            if (!context.Comments.Any())
            {
                this.SeedComments(context);
            }
        }

        private void SeedRole(SnippetsDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole {Name = "Admin"};

            manager.Create(role);
        }

        private void SeedUsers(SnippetsDbContext context)
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var PasswordHash = new PasswordHasher();

            var user = new User
            {
                UserName = "someUser",
                Email = "someUser@example.com",
                PasswordHash = PasswordHash.HashPassword("password123")
            };

            UserManager.Create(user);

            var user1 = new User
            {
                UserName = "newUser",
                Email = "new_user@gmail.com",
                PasswordHash = PasswordHash.HashPassword("password123")
            };

            UserManager.Create(user1);

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user2 = new User
                {
                    UserName = "admin",
                    Email = "admin@snippy.softuni.com",
                    PasswordHash = PasswordHash.HashPassword("admin123")
                };

                UserManager.Create(user2);
                UserManager.AddToRole(user2.Id, "Admin");
            }
        }

        private void SeedLabels(SnippetsDbContext context)
        {
            var listLabels = new List<string>()
            {
                "bug",
                "funny",
                "jquery",
                "mysql",
                "useful",
                "web",
                "geometry",
                "back-end",
                "front-end",
                "games"
            };

            foreach (var currLabel in listLabels)
            {
                var label = new Label
                {
                    Text = currLabel.Trim()
                };

                context.Labels.Add(label);
            }

            context.SaveChanges();
        }

        private void SeedLanguages(SnippetsDbContext context)
        {
            var listLanguages = new List<string>()
            {
                "C#",
                "JavaScript",
                "Python",
                "CSS",
                "SQL",
                "PHP"
            };

            foreach (var currLanguage in listLanguages)
            {
                var language = new Language
                {
                    Name = currLanguage
                };

                context.Languages.Add(language);
            }

            context.SaveChanges();
        }

        private void SeedSnippets(SnippetsDbContext context)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-US");

            var listOfSnippets = new List<string>()
            {
                @"Ternary Operator Madness
                | This is how you DO NOT user ternary operators in C#!
                | bool X = Glob.UserIsAdmin ? true : false; 
                | admin 
                | 26.10.2015 17:20:33
                | C#
                | funny",



                @"Points Around A Circle For GameObject Placement
                | Determine points around a circle which can be used to place elements around a central point
                | private Vector3 DrawCircle(float centerX, float centerY, float radius, float totalPoints, float currentPoint)
                {
	                float ptRatio = currentPoint / totalPoints;
	                float pointX = centerX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;
	                float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;

	                Vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);

	                return panelCenter;
                }
 
                | admin 
                | 26.10.2015 20:15:30
                | C#
                | geometry, games",


                @"forEach. How to break?
                | Array.prototype.forEach You can't break forEach. So use 'some' or 'every'. Array.prototype.some some is pretty much the same as forEach but it break when the callback returns true. Array.prototype.every every is almost identical to some except it's expecting false to break the loop.
                | var ary = [" + "\"JavaScript@\" " + ", " + "\"Java\" " + ", " + "\"CoffeeScript\"" + ", " +
                "\"TypeScript\"" + "];" +

                "ary.some(function (value, index, _ary) {" +
                "console.log(index + " + "\": " + "\" + value);" +
                "return value === " + "\"CoffeeScript\"" + ";" +

                "});" +
                "// output:" +
                "// 0: JavaScript" +
                "// 1: Java" +
                "// 2: CoffeeScript" +

                "ary.every(function(value, index, _ary) {" +
                "console.log(index + " + "\": " + "\" + value);" +
                "return value.indexOf(" + "\"Script" + "\") > -1;" + "\" " +
                "});" +
                "// output:" +
                "// 0: JavaScript" +
                "// 1: Java" +

                " | newUser " +
                " | 27.10.2015 10:53:20" +
                " | JavaScript" +
                " | jquery, useful, web, front-end",

                @"Numbers only in an input field
                | Method allowing only numbers (positive / negative / with commas or decimal points) in a field
                | $(" + "\"#input" + "\").keypress(function(event){" +
                "var charCode = (event.which) ? event.which : window.event.keyCode;" +
                "if (charCode <= 13) { return true; } " +
                "else {" +
                "var keyChar = String.fromCharCode(charCode);" +
                "var regex = new RegExp(" + "\"[0-9,.-]" + "\");" +
                "return regex.test(keyChar); " +
                "}" +
                "});" +

                " | someUser" +
                " | 28.10.2015 09:00:56" +
                " | JavaScript" +
                " | web, front-end",

                @"Create a link directly in an SQL query
                | That's how you create links - directly in the SQL!
                | SELECT DISTINCT
                              b.Id,
                              concat('<button type=""button"" onclick=""DeleteContact(', cast(b.Id as char), ')"">Delete...</button>') as lnkDelete
                FROM tblContact   b
                WHERE ....
 
                | admin 
                | 30.10.2015 11:20:00
                | SQL
                | bug, funny, mysql",


                @"Reverse a String 
                | Almost not worth having a function for... 
                | def reverseString(s): " +
                "\"\"\"Reverses a string given to it.\"\"\" " +
                "return s[::-1] " +
                " | admin " +
                " | 26.10.2015 09:35:13" +
                " | Python" +
                " | useful",

                @"Pure CSS Text Gradients
                | This code describes how to create text gradients using only pure CSS
                | /* CSS text gradients */
                    h2[data-text] {
	                    position: relative;
                    }
                    h2[data-text]::after {
	                    content: attr(data-text);
	                    z-index: 10;
	                    color: #e3e3e3;
	                    position: absolute;
	                    top: 0;
	                    left: 0;
	                    -webkit-mask-image: -webkit-gradient(linear, left top, left bottom, from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)));
 
                | someUser 
                | 22.10.2015 19:26:42
                | CSS
                | web, front-end",

                @"Check for a Boolean value in JS
                | THow to check a Boolean value - the wrong but funny way :D
                | var b = true;

                    if (b.toString().length < 5) {
                      //...
                    }

                | admin 
                | 22.10.2015 05:30:04
                | JavaScript
                | funny",
            };

            foreach (var snippet in listOfSnippets)
            {
                var comp = snippet.Split('|');
                var title = comp[0].Trim();
                var description = comp[1].Trim();
                var code = comp[2].Trim();
                var authorName = comp[3].Trim();
                var author = context.Users.FirstOrDefault(u => u.UserName == authorName);
                var currDateTime = comp[4].Trim();
                var creationTime = DateTime.ParseExact(currDateTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                var languageName = comp[5].Trim();
                var language = context.Languages.FirstOrDefault(l => l.Name == languageName);
                var allLabels = comp[6].Split(',');
                var allLabelsToList =
                    allLabels.Select(label => context.Labels.FirstOrDefault(l => l.Text == label.Trim())).ToList();

                var snippetDb = new Snippet()
                {
                    Title = title,
                    Description = description,
                    Code = code,
                    User = author,
                    CreationTime = creationTime,
                    Language = language,
                    Labels = allLabelsToList
                };

                context.Snippets.Add(snippetDb);
            }

            context.SaveChanges();
        }

        private void SeedComments(SnippetsDbContext context)
        {
            var listOfComments = new List<string>()
            {
                @"Now that's really funny! I like it! | admin | 30.10.2015 11:50:38 | Ternary Operator Madness" ,
                @"Here, have my comment! | newUser | 01.11.2015 15:52:42 | Ternary Operator Madness" ,
                @"I didn't manage to comment first :( | someUser | 02.11.2015 05:30:20 | Ternary Operator Madness" ,
                @"That's why I love Python - everything is so simple! | newUser | 27.10.2015 15:28:14 | Reverse a String" ,
                @"I have always had problems with Geometry in school. Thanks to you I can now do this without ever having to learn this damn subject | someUser | 29.10.2015 15:08:42 | Points Around A Circle For GameObject Placement" ,
                @"Thank you. However, I think there must be a simpler way to do this. I can't figure it out now, but I'll post it when I'm ready. | admin | 03.11.2015 12:56:20 | Numbers only in an input field" ,
            };

            foreach (var comment in listOfComments)
            {
                var comp = comment.Split('|');
                var content = comp[0].Trim();
                var authorName = comp[1].Trim();
                var author = context.Users.FirstOrDefault(u => u.UserName == authorName);
                var currDateTime = comp[2].Trim();
                var creationTime = DateTime.ParseExact(currDateTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                var snippetTitle = comp[3].Trim();
                var snippet = context.Snippets.FirstOrDefault(s => s.Title == snippetTitle);

                var commentDb = new Comment()
                {
                    Content = content,
                    Author = author,
                    CreationTime = creationTime,
                    Snippet = snippet
                };

                context.Comments.Add(commentDb);
            }

            context.SaveChanges();
        }
    }
}
