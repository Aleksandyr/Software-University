using System;

namespace Point
{
    public class Point3D
    {
        private double x;
        private double y;
        private double z;

        private static readonly Point3D startPosition = new Point3D(0, 0, 0);
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X 
        {
            get { return this.x; } 
            private set { this.x = value; }
        }

        public double Y 
        {
            get { return this.y; } 
            private set { this.y = value; }
        }

        public double Z 
        {
            get { return this.z; } 
            private set { this.z = value; }
        }

        public static string StartPoin()
        {
            return startPosition.ToString();
        }

        public override string ToString()
        {
            return String.Format("Point3D({0},{1},{2})", this.X, this.Y, this.Z);
        }
    }
}
