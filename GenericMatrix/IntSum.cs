namespace MatrixLibrary
{
    /// <summary>
    /// Interface that provides method Sum 
    /// to define logics of this operation
    /// </summary>
    /// <typeparam name="T">Value of reference type</typeparam>
    public interface ISum<T>
    {
        T[,] Sum(T[,] arg1, T[,] arg2);
    }

    /// <summary>
    /// Class provides int sum logics
    /// for square matrix elements
    /// </summary>
    public class IntSum : ISum<int>
    {
        public int[,] Sum(int[,] arg1, int[,] arg2)
        {
            int maxI = arg1.GetLength(0);
            int maxJ = arg1.GetLength(1);
            int[,] array = new int[maxI, maxJ];

            for (int i = 0; i < maxI; i++)
            {
                for (int j = 0; j < maxJ; j++)
                {
                    array[i, j] = arg1[i, j] + arg2[i, j];
                }
            }

            return array;
        }
    }
}
