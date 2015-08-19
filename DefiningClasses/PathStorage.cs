﻿namespace ThreeDSpace
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static Path path = new Path();

        public static void Load(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        double x = 0;
                        double y = 0;
                        double z = 0;

                        string[] readPoints = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        x = double.Parse(readPoints[0]);
                        y = double.Parse(readPoints[1]);
                        z = double.Parse(readPoints[2]);

                        Point3D newPoint = new Point3D(x, y, z);

                        path.AddPoint(newPoint);

                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("No access to file!");
            }

        }

        public static void Save(Path pointsList, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Point3D point in pointsList.PointList)
                {
                    string line = string.Format("{0} {1} {2}", point.X, point.Y, point.Z);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
