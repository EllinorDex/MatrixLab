using MatrixLib.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test.OperationsDouble
{
    [TestClass]
    public class TestDeteminantDouble
    {
        [TestMethod]
        public void DeteminantUsersMatrix0()
        {
            var matrOfArray = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<double>(3, 3, matrOfArray);

            var matr = new Determinant<double>(a);

            var detem = matr.Calculate();

            Assert.AreEqual(0, detem);
        }

        [TestMethod]
        public void DeteminantUsersMatrixNumb()
        {
            var matrOfArray = new double[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<double>(3, 3, matrOfArray);

            var matr = new Determinant<double>(a);

            var detem = matr.Calculate();

            Assert.AreEqual(3, detem);
        }

        [TestMethod]
        public void DeteminantException()
        {
            var matrOfArray = new double[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 7, 8, 9 } };
            var a = new Matrix<double>(4, 3, matrOfArray);

            var dm = new Determinant<double>(a);

            Assert.ThrowsException<MatrixException>(() => dm.Calculate());
        }

        [TestMethod]
        public void GetSetDeterminantMatrixDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(4, 5);

            var matrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var c = new Matrix<double>(4, 3, matrA);
            var sm = new Determinant<double>(a);

            sm.MatrixOperand = c;

            CollectionAssert.AreEqual(sm.MatrixOperand.Get2DArray(), c.Get2DArray());

        }
    }
}
