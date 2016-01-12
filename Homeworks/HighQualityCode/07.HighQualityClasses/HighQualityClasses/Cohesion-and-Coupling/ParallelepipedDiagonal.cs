namespace CohesionAndCoupling
{
    public static class ParallelepipedDiagonal
    {
        public static double CalcDiagonalXYZ(Parallelepiped parallelepiped)
        {
            double distance = DistanceTwoPoints.CalcDistance3D(0, 0, 0, 
                parallelepiped.Width, parallelepiped.Height, parallelepiped.Depth);

            return distance;
        }

        public static double CalcDiagonalXY(Parallelepiped parallelepiped)
        {
            double distance = DistanceTwoPoints.CalcDistance2D(0, 0, parallelepiped.Width, parallelepiped.Height);
            return distance;
        }

        public static double CalcDiagonalXZ(Parallelepiped parallelepiped)
        {
            double distance = DistanceTwoPoints.CalcDistance2D(0, 0, parallelepiped.Width, parallelepiped.Depth);
            return distance;
        }

        public static double CalcDiagonalYZ(Parallelepiped parallelepiped)
        {
            double distance = DistanceTwoPoints.CalcDistance2D(0, 0, parallelepiped.Height, parallelepiped.Depth);
            return distance;
        }
    }
}
