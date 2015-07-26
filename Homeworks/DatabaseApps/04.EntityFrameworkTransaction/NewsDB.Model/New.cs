using System.ComponentModel.DataAnnotations;

namespace NewsDB.Model
{
    public class New
    {
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string ContentNews { get; set; }
    }
}
