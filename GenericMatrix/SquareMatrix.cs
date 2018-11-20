using System;

namespace MatrixLibrary
{
    public delegate void MatrixStateHandler(string message);
    /// <summary>
    /// Class represents a square matrix
    /// </summary>
    /// <typeparam name="T">Some type value or reference</typeparam>
    public class SquareMatrix<T>
    {
        protected static ISum<T> sum;
        protected event MatrixStateHandler Modification;

        /// <summary>
        /// Constructor initializes matrix elements and 
        /// way of sum matrix of class type
        /// </summary>
        /// <param name="_array">Matrix elements</param>
        /// <param name="_sum">Way of sum matrix of class type</param>
        public SquareMatrix(T[,] _array, ISum<T> _sum)
        {
            Modification = Listeners.MatrixModification;

            Validation(_array);

            Array = _array;

            sum = _sum;
        }

        public T[,] Array { get; private set; }

        /// <summary>
        /// Overload of plus operation 
        /// </summary>
        /// <param name="arg1">First matrix</param>
        /// <param name="arg2">Second matrix</param>
        /// <returns>New class object with summed coefficients</returns>
        public static SquareMatrix<T> operator +(SquareMatrix<T> arg1, SquareMatrix<T> arg2)
        {
            return new SquareMatrix<T>(sum.Sum(arg1.Array, arg2.Array), sum);
        }

        /// <summary>
        /// Method allows to chande data in the cell of the matrix
        /// </summary>
        /// <param name="i">First dimension</param>
        /// <param name="j">Second dimension</param>
        /// <param name="arg">Value</param>
        public void ChangeCell(int i, int j, T arg)
        { 
            InRange(i, j);

            Array[i, j] = arg;

            Modified($"Cell [{i}, {j}] modified at {this.GetType().Name}");
        }
        
        /// <summary>
        /// Method calls listeners of the change event
        /// </summary>
        /// <param name="message">Some sembols that brings info about event</param>
        protected void Modified(string message)
        {
            Modification?.Invoke(message);
        }

        /// <summary>
        /// Method validates matrix for some conditions
        /// </summary>
        /// <param name="array">Input matrix coefficients</param>
        protected virtual void Validation(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException("Matrix is not square!");
            }
        }

        /// <summary>
        /// Method validates is the indexes in the range of matrix dimensions
        /// </summary>
        /// <param name="i">First dimension</param>
        /// <param name="j">Second dimension</param>
        private void InRange(int i, int j)
        {
            if (i > Array.GetLength(0) || j > Array.GetLength(1))
            {
                throw new ArgumentException("Indexes of insert element are not valid!");
            }
        }
    }
}
