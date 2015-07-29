namespace Mountains.Models
{
    public class Peak
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int Elevation { get; set; }
        public int MountainId { get; set; }
        public virtual Mountain Mountain { get; set; }
    }
}
