using MatrixLib.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test.OperationsDouble
{
    [TestClass]
    public class TestSumDouble
    {

        [TestMethod]
        public void SumZerosMatrixDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(5, 7);
            var b = Matrix<double>.CreateZeroMatrix(5, 7);

            var sum = new Sum<double>(a, b);

            var c = sum.Calculate();

            Assert.AreEqual(a, c);
        }

        [TestMethod]
        public void SumUsersMatrixDouble()
        {
            var matrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var resultArr = new double[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            var a = new Matrix<double>(4, 3, matrA);
            var b = new Matrix<double>(4, 3, matrA);
            var resultMatr = new Matrix<double>(4, 3, resultArr);

            var sum = new Sum<double>(a, b);

            var c = sum.Calculate();

            Assert.AreEqual(resultMatr, c);
        }

        [TestMethod]
        public void SumMatrixExceptionDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(4, 5);
            var b = Matrix<double>.CreateZeroMatrix(5, 4);
            var sm = new Sum<double>(a, b);

            Assert.ThrowsException<MatrixException>(() => sm.Calculate());
        }

        [TestMethod]
        public void GetSetSumMatrixDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(4, 5);
            var b = Matrix<double>.CreateZeroMatrix(5, 5);

            var matrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var c = new Matrix<double>(4, 3, matrA);
            var d = new Matrix<double>(4, 3, matrA);
            var sm = new Sum<double>(a, b);

            sm.MatrixLeft = c;
            sm.MatrixRight = d;

            Assert.AreEqual(sm.MatrixLeft, c);
            Assert.AreEqual(sm.MatrixRight, d);

        }
    }
}
