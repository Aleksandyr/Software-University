using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mountains.Models
{
    public class Country
    {
        private ICollection<Mountain> mountains;

        public Country()
        {
            this.mountains = new HashSet<Mountain>();
        }

        [Key]
        [MaxLength(2)]
        [MinLength(2)]
        [Column(TypeName = "char")]
        public string CountryCode { get; set; }
        public string ContryName { get; set; }

        public virtual ICollection<Mountain> Mountains 
        { 
            get { return this.mountains; } 
            set { this.mountains = value; } 
        }
    }
}
