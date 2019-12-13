using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MatrixTestDouble
{
    [TestClass]
    public class TestMatrixDouble
    {

        [TestMethod]
        public void ConstractOnesMatrixNormDouble()
        {
            //Лучше сделать сравнение с двумерным массивом(1 ассерт + полная проверка)
            var a = new Matrix<double>(5, 5, MatrixType.Ones);

            Assert.AreEqual(1, a[2, 2]);
            Assert.AreEqual(0, a[3, 2]);
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangleDouble()
        {
            Assert.ThrowsException<MatrixException>(() => new Matrix<double>(7, 5, MatrixType.Ones));
        }

        [TestMethod]
        public void ConstractZerosMatrixNormDouble()
        {
            var a = new Matrix<double>(7, 5, MatrixType.Zeros);

            var matr = new double[5, 7];

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void ConstractUsersMatrixNormDouble()
        {
            var matr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<double>(2, 3, matr);

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void MethodGetSizeMatrixDouble()
        {
            var a = new Matrix<double>(5, 5, MatrixType.Ones);

            Assert.AreEqual(5, a.CountOfColumns);
            Assert.AreEqual(5, a.CountOfRows);
        }

        [TestMethod]
        public void MethodGetMatrixRectangleDouble()
        {
            var matr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<double>(2, 3, matr);
            var matrA = a.Get2DArray();
            matrA[1, 1] = 10;

            Assert.AreEqual(matr[1, 1], a[1, 1]);
        }

    }
}
