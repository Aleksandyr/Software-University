using System;
using Point;
using DistanceCalculate;
using System.Collections.Generic;
using StorageInfo;
using PointInfo;

namespace Program
{
    class Program
    {
        static void Main()
        {
            Point3D fPoint = new Point3D(-7, -4, 3);
            Point3D sPoint = new Point3D(17, 6, 2.5);

            var path = new List<Point3D>
            {
                new Point3D(-7, -4, 3),
                new Point3D(3, 2, 1),
                new Point3D(1, 2, 3)
            };

            Storage.SavePoints(path);
            Storage.LoadPoints(path);

            //Console.WriteLine(DistanceCalculator.DistCalc(fPoint, sPoint));
        }
    }
}
