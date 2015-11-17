namespace Paths
{
    using System.Collections.Generic;
    using Point3D;

    class Program
    {
        static void Main()
        {
            List<Point3D> points = new List<Point3D>()
            {
                new Point3D(2 ,3, 4),
                new Point3D(1 ,5, 2),
                new Point3D(-2 ,3, 7),
            };

            Path3D path = new Path3D(points);
            Storage.SavePointsInFile("@../../../../AllPoints.txt", path);

            var pointsFromFile = Storage.LoadPointsFromATextFile("@../../../../AllPoints.txt");

            foreach (var currPoint in pointsFromFile)
            {
                System.Console.WriteLine(currPoint is Point3D);
                System.Console.WriteLine("Point: " + currPoint);
            }
        }
    }
}
