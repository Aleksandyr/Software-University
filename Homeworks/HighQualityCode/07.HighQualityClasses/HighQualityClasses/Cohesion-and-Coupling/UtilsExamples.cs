using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileExtension.GetFileExtension("example"));
            Console.WriteLine(FileExtension.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtension.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileExtension.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileExtension.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtension.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                DistanceTwoPoints.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                DistanceTwoPoints.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped parallelepiped = new Parallelepiped(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", ParallelepipdeVolume.CalcVolume(parallelepiped));
            Console.WriteLine("Diagonal XYZ = {0:f2}", ParallelepipedDiagonal.CalcDiagonalXYZ(parallelepiped));
            Console.WriteLine("Diagonal XY = {0:f2}", ParallelepipedDiagonal.CalcDiagonalXY(parallelepiped));
            Console.WriteLine("Diagonal XZ = {0:f2}", ParallelepipedDiagonal.CalcDiagonalXZ(parallelepiped));
            Console.WriteLine("Diagonal YZ = {0:f2}", ParallelepipedDiagonal.CalcDiagonalYZ(parallelepiped));
        }
    }
}
