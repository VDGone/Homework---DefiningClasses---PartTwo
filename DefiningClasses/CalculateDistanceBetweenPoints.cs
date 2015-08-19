namespace ThreeDSpace
{
    using System;

    public static class CalculateDistanceBetweenTwoPoints
    {
        public static double CalculateDistance(Point3D pointX, Point3D pointY)
        {
             double distance = Math.Sqrt((pointX.X - pointY.X) * (pointX.X - pointY.X) +
                                        (pointX.Y - pointY.Y) * (pointX.Y - pointY.Y) +
                                        (pointX.Z - pointY.Z) * (pointX.Z - pointY.Z));
             return distance;
        }
    }
}
