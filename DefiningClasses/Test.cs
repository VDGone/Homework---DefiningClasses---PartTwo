namespace ThreeDSpace
{
    using System;

    class Test
    {
        public static void Main()
        {
            var pointOne = new Point3D(0, 4, 2);
            var pointTwo = new Point3D(2, 3, 4);

            Console.WriteLine(pointOne);
            Console.WriteLine(CalculateDistanceBetweenTwoPoints.CalculateDistance(pointOne,pointTwo));

            Path randomPath = new Path();
            randomPath.PointList.Add(pointOne);
            randomPath.PointList.Add(pointTwo);
            PathStorage.Save(randomPath, "randomPath");
            PathStorage.Save(randomPath, "randomPath");
            Console.WriteLine(PathStorage.path);

            PathStorage.Load("randomPath");
            Console.WriteLine(PathStorage.path);

            Matrix<int> matrixOne = new Matrix<int>(5, 5);
            Matrix<int> matrixTwo = new Matrix<int>(5, 5);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrixOne[i, j] = i + 2 * 2;
                    matrixTwo[i, j] = j + 1;
                }
            }

            Console.WriteLine("First matrix: \n{0}", matrixOne);
            Console.WriteLine("Second matrix: \n{0}", matrixTwo);

            Matrix<int> concatMatrix = matrixOne + matrixTwo;
            Console.WriteLine("Concatenated matrix: \n{0}", concatMatrix);

            Matrix<int> subtractMatrix = matrixOne - matrixTwo;
            Console.WriteLine("Subtracted matrix: \n{0}", subtractMatrix);

            Matrix<int> multiMatrix = matrixOne * matrixTwo;
            Console.WriteLine("Multiplied matrix: \n{0}", multiMatrix);

            var hasZero = matrixOne ? false : true;
            Console.WriteLine("Zeros test: {0}", hasZero);

            GenericList<int> arr = new GenericList<int>();

            arr.Add(5);
            arr.Add(3);
            arr.Add(10);
            arr.Add(12);

            arr.Remove(1);

            arr.Insert(4, 1);

            Console.WriteLine(arr);
            Console.WriteLine("Element with value {0} is at position {1}", 5, arr.FindElement(10));

            arr.Clear();
            Console.WriteLine("Cleared arr: {0}", arr);

            arr.Add(2);
            arr.Add(4);
            arr.Add(6);
            Console.WriteLine();
            Console.WriteLine("New Generic List:");
            Console.WriteLine(arr);
        }
    }
}
