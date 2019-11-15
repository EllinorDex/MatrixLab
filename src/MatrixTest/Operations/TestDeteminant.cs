using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.Operations
{
    [TestClass]
    public class TestDeteminant
    {
        [TestMethod]
        public void DeteminantOnesMatrix()
        {
            
            Matrix A = new Matrix((uint)5, (uint)5, MatrixType.ones);

            Determinant Matr = new Determinant(A);

            int  detem = Matr.Calculate();

            Assert.AreEqual(1, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrix0()
        {
            int[,] matrOfArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix A = new Matrix((uint)3, (uint)3, matrOfArray);

            Determinant Matr = new Determinant(A);

            int detem = Matr.Calculate();

            Assert.AreEqual(0, detem);
        }
        [TestMethod]
        public void DeteminantUsersMatrixNumb()
        {
            int[,] matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix A = new Matrix((uint)3, (uint)3, matrOfArray);

            Determinant Matr = new Determinant(A);

            int detem = Matr.Calculate();

            Assert.AreEqual(3, detem);
        }

        [TestMethod]
        public void DeteminantException()
        {
            int[,] matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 7, 8, 9 } };
            Matrix A = new Matrix((uint)4, (uint)3, matrOfArray);
            Determinant D = new Determinant(A);

            Assert.ThrowsException<MatrixException>(()=>D.Calculate());
        }
    }
}
