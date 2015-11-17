namespace Paths
{
    using System.Collections.Generic;
    using Point3D;

    public class Path3D
    {
        private List<Point3D> points;

        public Path3D(List<Point3D> points)
        {
            this.Points = points;
        }

        public List<Point3D> Points 
        { 
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }

        public override string ToString()
        {
            return string.Join("|", this.Points);
        }
    }
}
