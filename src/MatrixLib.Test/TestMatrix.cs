using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test
{
    [TestClass]
    public class TestMatrix
    {

        [TestMethod]
        public void ConstractOnesMatrixNorm()
        { 
            //Лучше сделать сравнение с двумерным массивом(1 ассерт + полная проверка)
            var a = Matrix<int>.CreateOnesMatrix(4, 4);

            Assert.AreEqual(1, a[2, 2]);
            Assert.AreEqual(0, a[3, 2]);
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangle()
        {
            Assert.ThrowsException<MatrixException>(() => Matrix<int>.CreateOnesMatrix(7, 5));
        }

        [TestMethod]
        public void ConstractZerosMatrixNorm()
        {
            var a = Matrix<int>.CreateZeroMatrix(5, 7);

            var matr = new int[5, 7];

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void ConstractUsersMatrixNorm()
        {
            var matr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<int>(2, 3, matr);

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void MethodGetSizeMatrix()
        {
            var a = Matrix<int>.CreateOnesMatrix(5, 5);

            Assert.AreEqual(5, a.CountOfColumns);
            Assert.AreEqual(5, a.CountOfRows);
        }

        [TestMethod]
        public void MethodGetMatrixRectangle()
        {
            var matr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<int>(2, 3, matr);
            var matrA = a.Get2DArray();
            matrA[1, 1] = 10;

            Assert.AreEqual(matr[1, 1], a[1, 1]);
        }

    }
}
