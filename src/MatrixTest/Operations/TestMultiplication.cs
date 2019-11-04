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
            int[,] resultMatr = new int[5, 3];
            Matrix A = new Matrix((uint)3, (uint)7, MatrixType.zeros);
            Matrix B = new Matrix((uint)7, (uint)5, MatrixType.zeros);

            Multiplication Mult = new Multiplication(A, B);

            Matrix C = Mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        [TestMethod]
        public void MultiplicationUsersMatrix()
        {
            int[,] MatrA = new[,] { { 1, 2 }, { 4, 5 }, { 7, 8 } };
            int[,] MatrB = new[,] { { 1, 3 }, { 2, 4 } };
            int[,] resultMatr = new int[,] { { 5, 11 }, { 14, 32 }, { 23, 53 } };
            Matrix A = new Matrix((uint)3, (uint)2, MatrA);
            Matrix B = new Matrix((uint)2, (uint)2, MatrB);

            Multiplication Mult = new Multiplication(A, B);

            Matrix C = Mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        //Кирилл, в этом тесте же вроде не должно выкидываться исключение
        [TestMethod]
        public void MultMatrixException()
        {
            Matrix A = new Matrix((uint)4, (uint)5, MatrixType.zeros);
            Matrix B = new Matrix((uint)4, (uint)5, MatrixType.zeros);

            Assert.ThrowsException<MatrixException>(() => new Multiplication(A, B));
        }
    }
}
