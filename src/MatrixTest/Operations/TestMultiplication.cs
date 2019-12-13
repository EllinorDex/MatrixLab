using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.Operations
{
    [TestClass]
    public class TestMultiplication
    {
        [TestMethod]
        public void MultiplicationZerosMatrix()
        {
            var resultMatr = new int[5, 3];
            var a = new Matrix<int>(3, 7, MatrixType.Zeros);
            var b = new Matrix<int>(7, 5, MatrixType.Zeros);

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
            var a = new Matrix<int>(4, 5, MatrixType.Zeros);
            var b = new Matrix<int>(4, 5, MatrixType.Zeros);
            var mult = new Multiplication<int>(a, b);

            var except = false;

            try
            {
                var m = mult.Calculate();
            }
            catch (MatrixException)
            {
                except = true;
            }

            Assert.IsTrue(except);
        }
    }
}
