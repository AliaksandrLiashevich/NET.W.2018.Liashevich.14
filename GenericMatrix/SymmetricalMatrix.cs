using System;

namespace MatrixLibrary
{
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Constructor initializes matrix elements and 
        /// way of sum matrix of class type
        /// </summary>
        /// <param name="_array">Matrix elements</param>
        /// <param name="_sum">Way of sum matrix of class type</param>
        public SymmetricalMatrix(T[,] _array, ISum<T> _sum) : base(_array, _sum)
        {
            Validation(_array);
        }

        /// <summary>
        /// Overload of plus operation 
        /// </summary>
        /// <param name="arg1">First matrix</param>
        /// <param name="arg2">Second matrix</param>
        /// <returns>New class object with summed coefficients</returns>
        public static SymmetricalMatrix<T> operator +(SymmetricalMatrix<T> arg1, SymmetricalMatrix<T> arg2)
        {
            return new SymmetricalMatrix<T>(sum.Sum(arg1.Array, arg2.Array), sum);
        }

        /// <summary>
        /// Method validates matrix for some conditions
        /// </summary>
        /// <param name="array">Input matrix coefficients</param>
        protected override void Validation(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!array[i, j].Equals(array[j, i]))
                    {
                        throw new ArgumentException("Matrix is not symmetrical!");
                    }
                }
            }
        }
    }
}
