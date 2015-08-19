namespace ThreeDSpace
{
    using System;

    public struct Point3D
    {
        private static readonly Point3D o;

        private double x;
        private double y;
        private double z;

        public Point3D(double xCoor, double yCoor, double zCoor):this()
        {
            this.x = xCoor;
            this.y = yCoor;
            this.z = zCoor;
        }

        static Point3D()
        {
            o = new Point3D(0, 0, 0);
        }

        public double X
        {
            get
            {
                return this.x;
            }
            private set
            {
                this.x = value;
            }
        }
        public double Y
        {
            get
            {
                return this.y;
            }
            private set
            {
                this.y = value;
            }
        }
        public double Z
        {
            get
            {
                return this.z;
            }
            private set
            {
                this.z = value;
            }
        }
        public static Point3D O
        {
            get
            {
                return o;
            }
        }
        public override string ToString()
        {
            return string.Format("X = {0}, Y = {1}, Z = {2}.", this.X, this.Y, this.Z);
        }
        
    }
}
