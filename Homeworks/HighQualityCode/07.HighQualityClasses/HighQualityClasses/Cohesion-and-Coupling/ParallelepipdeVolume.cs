namespace CohesionAndCoupling
{
    public static class ParallelepipdeVolume
    {
        public static double CalcVolume(Parallelepiped parallelepiped)
        {
            double volume = parallelepiped.Width * parallelepiped.Height * parallelepiped.Depth;
            return volume;
        }
    }
}
