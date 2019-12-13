using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MatrixTest
{
    [TestClass]
    public class TestMatrix
    {

        [TestMethod]
        public void ConstractOnesMatrixNorm()
        { 
            //Лучше сделать сравнение с двумерным массивом(1 ассерт + полная проверка)
            var a = new Matrix<int>(5, 5, MatrixType.Ones);

            Assert.AreEqual(1, a[2, 2]);
            Assert.AreEqual(0, a[3, 2]);
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangle()
        {
            Assert.ThrowsException<MatrixException>(() => new Matrix<int>(7, 5, MatrixType.Ones));
        }

        [TestMethod]
        public void ConstractZerosMatrixNorm()
        {
            var a = new Matrix<int>(7, 5, MatrixType.Zeros);

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
            var a = new Matrix<int>(5, 5, MatrixType.Ones);
            
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
