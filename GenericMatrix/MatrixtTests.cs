using NUnit.Framework;
using MatrixLibrary;

namespace Matrix.Tests
{
    [TestFixture]
    public class MatrixtTests
    {
        static int[,] squareArray = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        static int[,] squareResult = new int[,] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };

        static int[,] diagonalArray = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        static int[,] diagonalResult = new int[,] { { 2, 0, 0 }, { 0, 2, 0 }, { 0, 0, 2 } };

        static int[,] symmetricalArray = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        static int[,] symmetricalResult = new int[,] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };

        static int[,] symDiagResult = new int[,] { { 2, 1, 1 }, { 1, 2, 1 }, { 1, 1, 2 } };

        [Test]
        public void PlustOperator_SquareAndSquare_SquareMatrix()
        {
            SquareMatrix<int> inMatrix = new SquareMatrix<int>(squareArray, new IntSum());
            SquareMatrix<int> outMatrix = inMatrix + inMatrix;

            Assert.AreEqual(squareResult, outMatrix.Array);
        }

        [Test]
        public void PlustOperator_DiagonalAndDiagonal_DiagonalMatrix()
        {
            DiagonalMatrix<int> inMatrix = new DiagonalMatrix<int> (diagonalArray, new IntSum());
            DiagonalMatrix<int> outMatrix = inMatrix + inMatrix;

            Assert.AreEqual(diagonalResult, outMatrix.Array);
        }

        [Test]
        public void PlustOperator_SymmetricalAndSymmetrical_SymmetricalMatrix()
        {
            SymmetricalMatrix<int> inMatrix = new SymmetricalMatrix<int>(symmetricalArray, new IntSum());
            SymmetricalMatrix<int> outMatrix = inMatrix + inMatrix;

            Assert.AreEqual(symmetricalResult, outMatrix.Array);
        }

        [Test]
        public void PlustOperator_SymmetricalAndDiagonal_SquareMatrix()
        {
            SymmetricalMatrix<int> inMatrix1 = new SymmetricalMatrix<int>(symmetricalArray, new IntSum());
            DiagonalMatrix<int> inMatrix2 = new DiagonalMatrix<int> (diagonalArray, new IntSum());
            SquareMatrix<int> outMatrix = inMatrix1 + inMatrix2;

            Assert.AreEqual(symDiagResult, outMatrix.Array);
        }
    }
}
