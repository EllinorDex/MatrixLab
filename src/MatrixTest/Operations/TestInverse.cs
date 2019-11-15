using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Moq;

namespace MatrixTest.Operations
{
    [TestClass]
    public class TestInverse
    {
        [TestMethod]
        public void InverseOnesMatrix()
        {
            Matrix A = new Matrix((uint)5, (uint)5, MatrixType.ones);

            InverseMatrix Matr = new InverseMatrix(A);

            Matrix Inverse = Matr.Calculate();

            CollectionAssert.AreEqual(A.Get2DArray(), Inverse.Get2DArray());
        }

        [TestMethod]
        public void InverseUsersMatrix0()
        {
            int[,] matrOfArray = new int[,] { { 2, 6, 5 }, { 5, 3, -2 }, { 7, 4, -3 } };
            int[,] resultMatr = new int[,] { { 1, -38, 27 }, { -1, 41, -29 }, { 1, -34, 24 } };
            Matrix A = new Matrix((uint)3, (uint)3, matrOfArray);

            InverseMatrix Matr = new InverseMatrix(A);

            Matrix Inverse = Matr.Calculate();

            CollectionAssert.AreEqual(resultMatr, Inverse.Get2DArray());
        }
        [TestMethod]
        public void InverseUsersMatrixNumb()
        {
            //TODO: Странный тест, я его немного переделал, но обрати внимание
            int[,] matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] resultMatr = new int[,] { { }, { }, { } };
            Matrix A = new Matrix((uint)3, (uint)3, matrOfArray);

            InverseMatrix Matr = new InverseMatrix(A);

            Matrix inverse = Matr.Calculate();

            Assert.AreEqual(-1, inverse[0,0]); // БЫЛО Assert.AreEqual(3, detem);
        }

        [TestMethod]
        public void InverseException()
        {
            int[,] matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 7, 8, 9 } };


            Matrix A = new Matrix((uint)4, (uint)3, matrOfArray);

            InverseMatrix IM = new InverseMatrix(A);

            Assert.ThrowsException<MatrixException>(() => IM.Calculate());
        }

        [TestMethod]
        public void IsCorrectNotException()
        {
            int[,] matrOfArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix A = new Matrix((uint)3, (uint)3, matrOfArray);
            InverseMatrix IM = new InverseMatrix(A);

            Assert.ThrowsException<MatrixException>(() => IM.Calculate());
        }
    }
}
