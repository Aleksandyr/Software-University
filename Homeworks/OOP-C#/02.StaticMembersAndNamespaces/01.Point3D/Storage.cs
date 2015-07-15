using System;
using Point;
using System.IO;
using System.Collections.Generic;

namespace StorageInfo
{
    public static class Storage
    {
        public static void SavePoints(List<Point3D> points)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"E:\SoftUni\Homework\Leve 2\OOP\02.StaticMembersAndNamespaces\points.txt"))
                {
                    foreach (var point in points)
                    {
                        sw.WriteLine(point.ToString());
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory is not found!");
            }
        }

        public static void LoadPoints(List<Point3D> points)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"E:\SoftUni\Homework\Leve 2\OOP\02.StaticMembersAndNamespaces\points.txt"))
                {
                    string line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Incorrect path!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
        }
    }
}
