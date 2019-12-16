using MatrixLib.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test.Operations
{
    [TestClass]
    public class TestSum
    {

        [TestMethod]
        public void SumZerosMatrix()
        {
            var a = Matrix<int>.CreateZeroMatrix(5, 7);
            var b = Matrix<int>.CreateZeroMatrix(5, 7);

            var sum = new Sum<int>(a, b);

            var c = sum.Calculate();

            Assert.AreEqual(a, c);
        }

        [TestMethod]
        public void SumUsersMatrix()
        {
            var matrA = new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var resultArr = new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 }, { 20, 22, 24 } };
            var a = new Matrix<int>(4, 3, matrA);
            var b = new Matrix<int>(4, 3, matrA);
            var resultMatr = new Matrix<int>(4, 3, resultArr);

            var sum = new Sum<int>(a, b);

            var c = sum.Calculate();

            Assert.AreEqual(resultMatr, c);
        }

        [TestMethod]
        public void SumMatrixException()
        {
            var a = Matrix<int>.CreateZeroMatrix(4, 5);
            var b = Matrix<int>.CreateZeroMatrix(4, 4);
            var sm = new Sum<int>(a, b);

            Assert.ThrowsException<MatrixException>(() => sm.Calculate());
        }

    }
}
