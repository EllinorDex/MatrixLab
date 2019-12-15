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
            var a = Matrix<int>.CreateOnesMatrix(5, 5);

            var matr = new InverseMatrix<int>(a);

            var inverse = matr.Calculate();

            CollectionAssert.AreEqual(a.Get2DArray(), inverse.Get2DArray());
        }

        [TestMethod]
        public void InverseUsersMatrix0()
        {
            var matrOfArray = new int[,] { { 2, 6, 5 }, { 5, 3, -2 }, { 7, 4, -3 } };
            var resultMatr = new int[,] { { 1, -38, 27 }, { -1, 41, -29 }, { 1, -34, 24 } };
            var a = new Matrix<int>(3, 3, matrOfArray);

            var matr = new InverseMatrix<int>(a);

            var inverse = matr.Calculate();

            CollectionAssert.AreEqual(resultMatr, inverse.Get2DArray());
        }
        [TestMethod]
        public void InverseUsersMatrixNumb()
        {
    
            var matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<int>(3, 3, matrOfArray);

            var matr = new InverseMatrix<int>(a);

            var inverse = matr.Calculate();

            Assert.AreEqual(-1, inverse[0,0]);
        }

        [TestMethod]
        public void InverseException()
        {
            var matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 7, 8, 9 } };

            var a = new Matrix<int>(4, 3, matrOfArray);
            var im = new InverseMatrix<int>(a);

            Assert.ThrowsException<MatrixException>(() => im.Calculate());
        }

        [TestMethod]
        public void IsCorrectNotException()
        {
            var matrOfArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<int>(3, 3, matrOfArray);
            var im = new InverseMatrix<int>(a);

            Assert.ThrowsException<MatrixException>(() => im.Calculate());
        }
    }
}
