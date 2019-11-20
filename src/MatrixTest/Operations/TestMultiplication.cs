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
            Matrix<int> A = new Matrix<int>((uint)3, (uint)7, MatrixType.zeros);
            Matrix<int> B = new Matrix<int>((uint)7, (uint)5, MatrixType.zeros);

            Multiplication<int> Mult = new Multiplication<int>(A, B);

            Matrix<int> C = Mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        [TestMethod]
        public void MultiplicationUsersMatrix()
        {
            int[,] MatrA = new[,] { { 1, 2 }, { 4, 5 }, { 7, 8 } };
            int[,] MatrB = new[,] { { 1, 3 }, { 2, 4 } };
            int[,] resultMatr = new int[,] { { 5, 11 }, { 14, 32 }, { 23, 53 } };
            Matrix<int> A = new Matrix<int>((uint)3, (uint)2, MatrA);
            Matrix<int> B = new Matrix<int>((uint)2, (uint)2, MatrB);

            Multiplication<int> Mult = new Multiplication<int>(A, B);

            Matrix<int> C = Mult.Calculate();

            CollectionAssert.AreEqual(resultMatr, C.Get2DArray());
        }

        //Кирилл, в этом тесте же вроде не должно выкидываться исключение
        [TestMethod]
        public void MultMatrixException()
        {
            Matrix<int> A = new Matrix<int>((uint)4, (uint)5, MatrixType.zeros);
            Matrix<int> B = new Matrix<int>((uint)4, (uint)5, MatrixType.zeros);
            Multiplication<int> Mult = new Multiplication<int>(A, B);

            bool Except = false;

            try
            {
                Matrix<int> M = Mult.Calculate();
            }
            catch (MatrixException)
            {
                Except = true;
            }

            Assert.IsTrue(Except);
        }
    }
}
