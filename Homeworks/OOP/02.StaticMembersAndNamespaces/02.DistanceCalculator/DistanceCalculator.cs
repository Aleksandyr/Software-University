namespace DistanceCalculator
{
    using Point3D;
using System;

    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double xCalc = Math.Pow(secondPoint.X - firstPoint.X, 2);
            double yCalc = Math.Pow(secondPoint.Y - firstPoint.Y, 2);
            double zCalc = Math.Pow(secondPoint.Z - firstPoint.Z, 2);

            double d = Math.Pow(xCalc + yCalc + zCalc, 2);

            return d;
        }
    }
}
