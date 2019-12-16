using MatrixLib.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test.OperationsDouble
{
    [TestClass]
    public class TestMultiplicationDouble
    {
        [TestMethod]
        public void MultiplicationZerosMatrixDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(3, 7);
            var b = Matrix<double>.CreateZeroMatrix(7, 5);
            var resultMatr = Matrix<double>.CreateZeroMatrix(3, 5);

            var mult = new Multiplication<double>(a, b);

            var c = mult.Calculate();

            Assert.AreEqual(resultMatr, c);
        }

        [TestMethod]
        public void MultiplicationUsersMatrixDouble()
        {
            var matrA = new double[,] { { 1, 2 }, { 4, 5 }, { 7, 8 } };
            var matrB = new double[,] { { 1, 3 }, { 2, 4 } };
            var resultArr = new double[,] { { 5, 11 }, { 14, 32 }, { 23, 53 } };
            var a = new Matrix<double>(3, 2, matrA);
            var b = new Matrix<double>(2, 2, matrB);
            var resultMatr = new Matrix<double>(3, 2, resultArr);

            var mult = new Multiplication<double>(a, b);

            var c = mult.Calculate();

            Assert.AreEqual(resultMatr, c);
        }

        //Кирилл, в этом тесте же вроде не должно выкидываться исключение
        [TestMethod]
        public void MultMatrixExceptionDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(4,5);
            var b = Matrix<double>.CreateZeroMatrix(4, 5);
            var mult = new Multiplication<double>(a, b);

            Assert.ThrowsException<MatrixException>(() => mult.Calculate());
        }

        [TestMethod]
        public void GetSetMultMatrixDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(4, 5);
            var b = Matrix<double>.CreateOnesMatrix(5, 5);

            var matrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var c = new Matrix<double>(4, 3, matrA);
            var d = new Matrix<double>(4, 3, matrA);
            var sm = new Multiplication<double>(a, b);

            sm.MatrixLeft = c;
            //
            sm.MatrixRight = d;

            Assert.AreEqual(sm.MatrixLeft, c);
            Assert.AreEqual(sm.MatrixRight, d);

        }

    }
}
