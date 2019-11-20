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
            
            Matrix<int> A = new Matrix<int>((uint)5, (uint)5, MatrixType.ones);

            Determinant<int> Matr = new Determinant<int>(A);

            int  detem = Matr.Calculate();

            Assert.AreEqual(1, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrix0()
        {
            int[,] matrOfArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix<int> A = new Matrix<int>((uint)3, (uint)3, matrOfArray);

            Determinant<int> Matr = new Determinant<int>(A);

            int detem = Matr.Calculate();

            Assert.AreEqual(0, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrixNumb()
        {
            int[,] matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrix<int> A = new Matrix<int>((uint)3, (uint)3, matrOfArray);

            Determinant<int> Matr = new Determinant<int>(A);

            int detem = Matr.Calculate();

            Assert.AreEqual(3, detem);
        }

        [TestMethod]
        public void DeteminantException()
        {
            int[,] matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 7, 8, 9 } };
            Matrix<int> A = new Matrix<int>((uint)4, (uint)3, matrOfArray);

            Determinant<int> DM = new Determinant<int>(A);

            Assert.ThrowsException<MatrixException>(() => DM.Calculate());
        }
    }
}
