using System.Collections.Generic;
using StudentSystem.Model;

namespace StudentSyste.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSyste.Data.StudentSystemEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            ContextKey = "StudentSyste.Data.StudentSystemEntities";
        }

        protected override void Seed(StudentSyste.Data.StudentSystemEntities context)
        {
            if (!context.Students.Any())
            {
                var student = new Student()
                {
                    Name = "Ivan Ivanov",
                    PhoneNumber = "+359 888 888 888",
                    RegistrationDate = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "DBA course",
                            Description = "Cool course!",
                            StartDate = new DateTime(2015,1,1),
                            EndDate = new DateTime(2016,10,1),
                            Price = 1000m,
                            Homewroks = new List<Homewrok>()
                            {
                                new Homewrok()
                                {
                                    Content = "some cool shit",
                                    SubmissionDate = DateTime.Now,
                                    ContentType = ContentType.zip
                                }
                            },
                            Resources = new List<Resource>()
                            {
                                new Resource()
                                {
                                    Name = "book on cool stuff",
                                    TypeOfResource = TypeOfResource.Other,
                                    URL = "None"
                                }
                            }
                        }
                    }
                };

                context.Students.Add(student);
                context.SaveChanges();
            }

            base.Seed(context);
        }
    }
}
