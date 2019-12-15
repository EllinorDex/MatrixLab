using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.OperationsDouble
{
    [TestClass]
    public class TestSumDouble
    {

        [TestMethod]
        public void SumZerosMatrixDouble()
        {
            var resultMatr = new double[5, 7];
            var a = new Matrix<double>(5, 7, MatrixType.Zeros);
            var b = new Matrix<double>(5, 7, MatrixType.Zeros);

            var sum = new Sum<double>(a, b);

            var c = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, c.Get2DArray());
        }

        [TestMethod]
        public void SumUsersMatrixDouble()
        {
            var matrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var resultMatr = new double[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            var a = new Matrix<double>(4, 3, matrA);
            var b = new Matrix<double>(4, 3, matrA);

            var sum = new Sum<double>(a, b);

            var c = sum.Calculate();

            CollectionAssert.AreEqual(resultMatr, c.Get2DArray());
        }

        [TestMethod]
        public void SumMatrixExceptionDouble()
        {
            var a = new Matrix<double>(4, 5, MatrixType.Zeros);
            var b = new Matrix<double>(5, 4, MatrixType.Zeros);
            var sm = new Sum<double>(a, b);

            Assert.ThrowsException<MatrixException>(() => sm.Calculate());
        }

        [TestMethod]
        public void GetSetSumMatrixDouble()
        {
            var a = new Matrix<double>(4, 5, MatrixType.Zeros);
            var b = new Matrix<double>(5, 5, MatrixType.Ones);

            var matrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var resultMatr = new double[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            var c = new Matrix<double>(4, 3, matrA);
            var d = new Matrix<double>(4, 3, matrA);
            var sm = new Sum<double>(a, b);

            sm.MatrixLeft = c;
            sm.MatrixRight = d;

            CollectionAssert.AreEqual(sm.MatrixLeft.Get2DArray(), c.Get2DArray());
            CollectionAssert.AreEqual(sm.MatrixRight.Get2DArray(), c.Get2DArray());

        }
    }
}
