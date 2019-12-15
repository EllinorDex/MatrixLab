using MatrixLib.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test.Operations
{
    [TestClass]
    public class TestDeteminant
    {
        [TestMethod]
        public void DeteminantOnesMatrix()
        {
            
            var a = Matrix<int>.CreateOnesMatrix(5, 5);

            var matr = new Determinant<int>(a);

            var  detem = matr.Calculate();

            Assert.AreEqual(1, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrix0()
        {
            var matrOfArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<int>(3, 3, matrOfArray);

            var matr = new Determinant<int>(a);

            var detem = matr.Calculate();

            Assert.AreEqual(0, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrixNumb()
        {
            var matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<int>(3, 3, matrOfArray);

            var matr = new Determinant<int>(a);

            var detem = matr.Calculate();

            Assert.AreEqual(3, detem);
        }

        [TestMethod]
        public void DeteminantException()
        {
            var matrOfArray = new int[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 7, 8, 9 } };
            var a = new Matrix<int>(4, 3, matrOfArray);

            var dm = new Determinant<int>(a);

            Assert.ThrowsException<MatrixException>(() => dm.Calculate());
        }
    }
}
