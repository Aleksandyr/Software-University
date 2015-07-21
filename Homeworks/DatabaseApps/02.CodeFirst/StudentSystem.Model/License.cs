using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class License
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
