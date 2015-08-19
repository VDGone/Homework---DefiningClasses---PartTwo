namespace ThreeDSpace
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Matrix<T> where T : IComparable
    {
        private T[,] matrixArr;
        private int row;
        private int col;

        public Matrix(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            matrixArr = new T [this.row, this.col];
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            private set
            {
                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
            private set
            {
                this.col = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= matrixArr.GetLength(0) || col < 0 || col >= matrixArr.GetLength(1))
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                return matrixArr[row, col];
            }
            set
            {
                if (row < 0 || row >= matrixArr.GetLength(0) || col < 0 || col >= matrixArr.GetLength(1))
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }
                this.matrixArr[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> mOne, Matrix<T> mTwo)
        {
            CheckSizeMatrices(mOne, mTwo);

            Matrix<T> resultMatrix = new Matrix<T>(mOne.matrixArr.GetLength(0), mOne.matrixArr.GetLength(1));

            for (int r = 0; r < mOne.matrixArr.GetLength(0); r++)
            {
                for (int c = 0; c < mOne.matrixArr.GetLength(1); c++)
                {
                    resultMatrix[r, c] = (dynamic)mOne[r, c] + mTwo[r, c];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> mOne, Matrix<T> mTwo)
        {
            CheckSizeMatrices(mOne, mTwo);

            Matrix<T> resultMatrix = new Matrix<T>(mOne.matrixArr.GetLength(0), mOne.matrixArr.GetLength(1));

            for (int r = 0; r < mOne.matrixArr.GetLength(0); r++)
            {
                for (int c = 0; c < mOne.matrixArr.GetLength(1); c++)
                {
                    resultMatrix[r, c] = (dynamic)mOne[r, c] - mTwo[r, c];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> mOne, Matrix<T> mTwo)
        {
            if (mOne.matrixArr.GetLength(0) != mTwo.matrixArr.GetLength(1))
            {
                throw new ArgumentException("Operation cannot be performed! Matrix's columns and rows must be equal!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(mOne.matrixArr.GetLength(0), mOne.matrixArr.GetLength(1));

            for (int r = 0; r < mOne.matrixArr.GetLength(0); r++)
            {
                for (int c = 0; c < mOne.matrixArr.GetLength(1); c++)
                {
                    for (int i = 0; i < mOne.matrixArr.GetLength(1); i++)
                    {
                        resultMatrix[r, c] = (dynamic)mOne[r, i] * mTwo[i, c];
                    }
                }
            }
            return resultMatrix;
        }

        private static void CheckSizeMatrices(Matrix<T> mOne, Matrix<T> mTwo)
        {
            if ((mOne.matrixArr.GetLength(0) != mTwo.matrixArr.GetLength(0)) ||
               (mOne.matrixArr.GetLength(1) != mTwo.matrixArr.GetLength(1)))
            {
                throw new ArgumentException("Operation cannot be performed! Matrix's sizes are different!");
            }
        }
        public static bool operator true(Matrix<T> matrix)
        {
            return TrueOrFalseOperator(matrix, true);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return TrueOrFalseOperator(matrix, false);
        }

        private static bool TrueOrFalseOperator(Matrix<T> matrix, bool trueOrFalse)
        {
            foreach (var element in matrix.matrixArr)
            {
                if (!element.Equals(default(T)))
                {
                    return trueOrFalse;
                }
            }

            return !trueOrFalse;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < this.matrixArr.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrixArr.GetLength(1); j++)
                {
                    stringBuilder.AppendFormat("{0,3}", this.matrixArr[i, j].ToString());
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
