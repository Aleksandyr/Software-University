using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Resource
    {
        private ICollection<License> licenses;

        public Resource()
        {
            this.licenses = new HashSet<License>();
        }

        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public TypeOfResource TypeOfResource { get; set; }
        public string URL { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses
        {
            get { return this.licenses; }
            set { this.licenses = value; }
        }
    }
}
