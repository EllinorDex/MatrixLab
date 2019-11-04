using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.Operations
{
    [TestClass]
    public class TestSum
    {

        [TestMethod]
        public void SumZerosMatrix()
        {
            int[,] resultMatr = new int[5, 7];
            Matrix A = new Matrix((uint)5, (uint)7, MatrixType.zeros);
            Matrix B = new Matrix((uint)5, (uint)7, MatrixType.zeros);

            Sum sum = new Sum(A, B);

            Matrix C = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        [TestMethod]
        public void SumUsersMatrix()
        {
            int[,] MatrA = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            int[,] resultMatr = new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            Matrix A = new Matrix((uint)4, (uint)3, MatrA);
            Matrix B = new Matrix((uint)4, (uint)3, MatrA);

            Sum sum = new Sum(A, B);

            Matrix C = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        [TestMethod]
        public void SumMatrixException()
        {
            Matrix A = new Matrix((uint)4, (uint)5, MatrixType.zeros);
            Matrix B = new Matrix((uint)5, (uint)4, MatrixType.zeros);

            Assert.ThrowsException<MatrixException>(() => new Sum(A, B));
        }
    }
}
