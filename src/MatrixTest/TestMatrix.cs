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
            Matrix A = new Matrix((uint)5, (uint)5, MatrixType.ones);

            Assert.AreEqual(1, A[2, 2]);
            Assert.AreEqual(0, A[3, 2]);
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangle()
        {
            //Проверил на матричное исключение
            Assert.ThrowsException<MatrixException>(() => new Matrix((uint)7, (uint)5, MatrixType.ones));

        }

        [TestMethod]
        public void ConstractZerosMatrixNorm()
        {
            Matrix A = new Matrix((uint)7, (uint)5, MatrixType.zeros);

            int[,] Matr = new int[5, 7];

            CollectionAssert.AreEqual(Matr, A.GetMatrix());
        }

        [TestMethod]
        public void ConstractUsersMatrixNorm()
        {
            int[,] Matr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix A = new Matrix((uint)3, (uint)2, Matr);

            CollectionAssert.AreEqual(Matr, A.GetMatrix());
        }

        [TestMethod]
        public void MethodGetSizeMatrix()
        {
            Matrix A = new Matrix((uint)5, (uint)5, MatrixType.ones);

            Assert.AreEqual((uint)5, A.CountOfColumns);
            Assert.AreEqual((uint)5, A.CountOfRows);
        }

        [TestMethod]
        public void MethodGetMatrixRectangle()
        {
            int[,] Matr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix A = new Matrix((uint)3, (uint)2, Matr);
            int[,] MatrA = A.GetMatrix();
            MatrA[1, 1] = 10;

            Assert.AreEqual(Matr[1, 1], A[1, 1]);
        }

    }
}
