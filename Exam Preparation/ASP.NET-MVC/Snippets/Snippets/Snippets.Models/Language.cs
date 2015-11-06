using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippets.Models
{
    public class Language
    {
        private ICollection<Snippet> snippets;

        public Language()
        {
            this.snippets = new HashSet<Snippet>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Snippet> Snippets
        {
            get
            {
                return this.snippets;
            }
            set
            {
                this.snippets = value;
            }

        }
    }
}
