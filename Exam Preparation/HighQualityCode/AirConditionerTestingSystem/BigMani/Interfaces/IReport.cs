namespace BigMani.Interfaces
{
    /// <summary>
    /// This interface implement Report propertis that the class need it.
    /// </summary>
    public interface IReport
    {
        string Manufacturer { get; }

        string Model { get; }

        int Mark { get; }
    }
}
