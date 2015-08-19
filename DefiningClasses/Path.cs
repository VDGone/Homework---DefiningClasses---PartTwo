namespace ThreeDSpace
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> pointList;

        public Path()
        {
            pointList = new List<Point3D>();
        }

        public List<Point3D> PointList
        {
            get 
            {
                return pointList; 
            }
            private set
            {
                this.pointList = value;
            }
        }

        public void AddPoint(Point3D point)
        {
            this.pointList.Add(point);
        }

        public void RemovePoint(Point3D point)
        {
            this.pointList.Remove(point);
        }
    }
}
