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
            Matrix<double> A = new Matrix<double>((uint)5, (uint)5, MatrixType.ones);

            Assert.AreEqual(1, A[2, 2]);
            Assert.AreEqual(0, A[3, 2]);
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangleDouble()
        {
            Assert.ThrowsException<MatrixException>(() => new Matrix<double>((uint)7, (uint)5, MatrixType.ones));
        }

        [TestMethod]
        public void ConstractZerosMatrixNormDouble()
        {
            Matrix<double> A = new Matrix<double>((uint)7, (uint)5, MatrixType.zeros);

            double[,] Matr = new double[5, 7];

            CollectionAssert.AreEqual(Matr, A.Get2DArray());
        }

        [TestMethod]
        public void ConstractUsersMatrixNormDouble()
        {
            double[,] Matr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix<double> A = new Matrix<double>((uint)2, (uint)3, Matr);

            CollectionAssert.AreEqual(Matr, A.Get2DArray());
        }

        [TestMethod]
        public void MethodGetSizeMatrixDouble()
        {
            Matrix<double> A = new Matrix<double>((uint)5, (uint)5, MatrixType.ones);

            Assert.AreEqual((uint)5, A.GetCountOfColumns());
            Assert.AreEqual((uint)5, A.GetCountOfRows());
        }

        [TestMethod]
        public void MethodGetMatrixRectangleDouble()
        {
            double[,] Matr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix<double> A = new Matrix<double>((uint)2, (uint)3, Matr);
            double[,] MatrA = A.Get2DArray();
            MatrA[1, 1] = 10;

            Assert.AreEqual(Matr[1, 1], A[1, 1]);
        }

    }
}
