using TheaterSystem.Core;
using TheaterSystem.Data;

namespace TheaterSystem
{
    using TheaterSystem.Core;
    using TheaterSystem.Data;

    public class Program
    {
        public static IPerformanceDatabase universal = new TheatreDatabase();

        public static void Main()
        {
            //IPerformanceDatabase data = new TheatreDatabase();
            TheatreEngine engine = new TheatreEngine();

            engine.Run();
        }
    }
}
