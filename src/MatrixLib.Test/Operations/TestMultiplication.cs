using MatrixLib.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test.Operations
{
    [TestClass]
    public class TestMultiplication
    {
        [TestMethod]
        public void MultiplicationZerosMatrix()
        {
            var resultMatr = new int[5, 3];
            var a = Matrix<int>.CreateZeroMatrix(3, 7);
            var b = Matrix<int>.CreateZeroMatrix(7, 5);

            var mult = new Multiplication<int>(a, b);

            var c = mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, c.Get2DArray());
        }

        [TestMethod]
        public void MultiplicationUsersMatrix()
        {
            var matrA = new[,] { { 1, 2 }, { 4, 5 }, { 7, 8 } };
            var matrB = new[,] { { 1, 3 }, { 2, 4 } };
            var resultMatr = new int[,] { { 5, 11 }, { 14, 32 }, { 23, 53 } };
            var a = new Matrix<int>(3, 2, matrA);
            var b = new Matrix<int>(2, 2, matrB);

            var mult = new Multiplication<int>(a, b);

            var c = mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, c.Get2DArray());
        }

        //Кирилл, в этом тесте же вроде не должно выкидываться исключение
        [TestMethod]
        public void MultMatrixException()
        {
            var a = Matrix<int>.CreateZeroMatrix(4, 5);
            var b = Matrix<int>.CreateZeroMatrix(4, 5);
            var mult = new Multiplication<int>(a, b);

            Assert.ThrowsException<MatrixException>(() => mult.Calculate());
        }
    }
}
