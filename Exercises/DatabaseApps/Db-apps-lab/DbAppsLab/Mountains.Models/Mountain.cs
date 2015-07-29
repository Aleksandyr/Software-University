using System.Collections.Generic;

namespace Mountains.Models
{
    public class Mountain
    {
         private ICollection<Country> countries;
         private ICollection<Peak> peakses;

        public Mountain()
        {
            this.countries = new HashSet<Country>();
            this.peakses = new HashSet<Peak>();
        }

        public int Id { get; set; }
        public string MountainName { get; set; }

        public virtual ICollection<Country> Countries
        {
            get { return this.countries; }
            set { this.countries = value; }
        }

        public virtual ICollection<Peak> Peakses
        {
            get { return this.peakses; }
            set { this.peakses = value; }
        }
    }
}
