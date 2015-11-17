namespace Paths
{
    using System.Collections.Generic;
    using System.IO;
    using Point3D;
    using System.Text.RegularExpressions;
    using System;

    public static class Storage
    {
        public static void SavePointsInFile(string fileName, Path3D path)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.Write(path);
            }
        }

        public static List<Point3D> LoadPointsFromATextFile(string fileName)
        {
            string container = string.Empty;
            List<Point3D> points = new List<Point3D>();

            using (StreamReader file = new StreamReader(fileName))
            {
                string line = file.ReadLine();
                while (line != null)
                {
                    var pointsFromFile = line.Split('|');
                    foreach (var point in pointsFromFile)
                    {
                        Regex expression = new Regex(@"[\-\+\s]*[0-9\s]");
                        var nums = expression.Matches(point);
                        
                        if (nums.Count < 3)
                        {
                            throw new InvalidOperationException("Incorrect point!");
                        }
                        
                        float firstNumber = float.Parse(nums[0].Value);
                        float secondNumber = float.Parse(nums[1].Value);
                        float thirdNumber = float.Parse(nums[2].Value);

                        var convertedPoint = new Point3D(firstNumber, secondNumber, thirdNumber);

                        points.Add(convertedPoint);
                    }

                    line = file.ReadLine();
                }
            }

            return points;
        }
    }
}
