namespace Point3D
{
    using System.Text;

    public class Point3D
    {
        private static readonly Point3D startPoint;

        private float x;
        private float y;
        private float z;

        static Point3D()
        {
            Point3D.startPoint = new Point3D(0, 0, 0);
        }

        public Point3D(float x, float y, float z)
        {
            this.X = x;
            this.y = y;
            this.Z = z;
        }

        public float X 
        { 
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public float Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public float Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        public static Point3D StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        public override string ToString()
        {
            string result = "{";
            result += string.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
            result += "}";

            return result;
        }
    }
}
