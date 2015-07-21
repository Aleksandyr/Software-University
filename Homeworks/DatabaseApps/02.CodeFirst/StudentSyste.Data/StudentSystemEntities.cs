using StudentSyste.Data.Migrations;
using StudentSystem.Model;

namespace StudentSyste.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemEntities : DbContext
    {
        public StudentSystemEntities()
            : base("StudentSystemEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemEntities, Configuration>());
        }

        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Resource> Resources { get; set; }
        public IDbSet<Homewrok> Homewroks { get; set; }
        public IDbSet<License> Licenses { get; set; }
    }
}