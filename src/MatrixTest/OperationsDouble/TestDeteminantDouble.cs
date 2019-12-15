using MatrixLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MatrixTest.OperationsDouble
{
    [TestClass]
    public class TestDeteminantDouble
    {
        [TestMethod]
        public void DeteminantOnesMatrix()
        {

            var a = Matrix<double>.CreateOnesMatrix(0, 0);

            var matr = new Determinant<double>(a);

            var detem = matr.Calculate();

            Assert.AreEqual(1, detem);
        }

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

            var except = false;

            try
            {
                var m = dm.Calculate();
            }
            catch (MatrixException)
            {
                except = true;
            }

            Assert.IsTrue(except);
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
