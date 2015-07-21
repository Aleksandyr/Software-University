using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Homewrok
    {
       public int Id { get; set; }
        [MaxLength(50)]
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
