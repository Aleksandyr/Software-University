namespace DistanceCalculator
{
    using Point3D;

    class Program
    {
        static void Main()
        {
            double distance = DistanceCalculator.CalculateDistance(new Point3D(2,3,4), new Point3D(3,4,5));
            System.Console.WriteLine(distance);
        }
    }
}
