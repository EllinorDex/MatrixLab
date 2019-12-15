using MatrixLib.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test.OperationsDouble
{
    [TestClass]
    public class TestInverseDouble
    {
        [TestMethod]
        public void InverseOnesMatrix()
        {
            var a = Matrix<double>.CreateOnesMatrix(5, 5);

            var matr = new InverseMatrix<double>(a);

            var inverse = matr.Calculate();

            CollectionAssert.AreEqual(a.Get2DArray(), inverse.Get2DArray());
        }

        [TestMethod]
        public void InverseUsersMatrix0Double()
        {
            var matrOfArray = new double[,] { { 2, 6, 5 }, { 5, 3, -2 }, { 7, 4, -3 } };
            var resultMatr = new double[,] { { 1, -38, 27 }, { -1, 41, -29 }, { 1, -34, 24 } };
            var a = new Matrix<double>(3, 3, matrOfArray);

            var matr = new InverseMatrix<double>(a);

            var inverse = matr.Calculate();

            CollectionAssert.AreEqual(resultMatr, inverse.Get2DArray());
        }
        [TestMethod]
        public void InverseUsersMatrixNumbDouble()
        {

            var matrOfArray = new double[,] { { 0, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<double>(3, 3, matrOfArray);

            var matr = new InverseMatrix<double>(a);

            var inverse = matr.Calculate();

            Assert.AreEqual(-1, inverse[0,0]);
        }

        [TestMethod]
        public void InverseExceptionDouble()
        {
            var matrOfArray = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var a = new Matrix<double>(3, 3, matrOfArray);
            var im = new InverseMatrix<double>(a);

            Assert.ThrowsException<MatrixException>(() => im.Calculate());
        }

        [TestMethod]
        public void GetSetSumMatrixDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(4, 5);

            var matrA = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            var c = new Matrix<double>(4, 3, matrA);
            var sm = new InverseMatrix<double>(a);

            sm.MatrixOperand = c;

            CollectionAssert.AreEqual(sm.MatrixOperand.Get2DArray(), c.Get2DArray());

        }

    }
}
