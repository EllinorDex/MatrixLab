using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixLib.Test
{
    [TestClass]
    public class TestMatrixDouble
    {

        [TestMethod]
        public void ConstractOnesMatrixNormDouble()
        {
            //Лучше сделать сравнение с двумерным массивом(1 ассерт + полная проверка)
            var a = Matrix<double>.CreateOnesMatrix(4, 4);

            Assert.AreEqual(1, a[2, 2]);
            Assert.AreEqual(0, a[3, 2]);
        }

        [TestMethod]
        public void ConstractOnesMatrixRectangleDouble()
        {
            Assert.ThrowsException<MatrixException>(() => Matrix<double>.CreateOnesMatrix(3, 4));
        }

        [TestMethod]
        public void ConstractZerosMatrixNormDouble()
        {
            var a = Matrix<double>.CreateZeroMatrix(7, 5);

            var matr = new double[5, 7];

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void ConstractUsersMatrixNormDouble()
        {
            var matr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<double>(2, 3, matr);

            CollectionAssert.AreEqual(matr, a.Get2DArray());
        }

        [TestMethod]
        public void MethodGetSizeMatrixDouble()
        {
            var a = Matrix<double>.CreateOnesMatrix(5, 5);

            Assert.AreEqual(5, a.CountOfColumns);
            Assert.AreEqual(5, a.CountOfRows);
        }

        [TestMethod]
        public void MethodGetMatrixRectangleDouble()
        {
            var matr = new double[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            var a = new Matrix<double>(2, 3, matr);
            var matrA = a.Get2DArray();
            matrA[1, 1] = 10;

            Assert.AreEqual(matr[1, 1], a[1, 1]);
        }

        [TestMethod]
        public void OperationEqualityTrue()
        {
            var matr = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsTrue(a == b);
        }

        [TestMethod]
        public void OperationEqualityFalse()
        {
            var matr = new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsFalse(a == b);
        }

        [TestMethod]
        public void OperationInequalityTrue()
        {
            var matr = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsFalse(a != b);
        }

        [TestMethod]
        public void OperationInequalityFalse()
        {
            var matr = new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            var b = Matrix<int>.CreateOnesMatrix(3, 3);
            Assert.IsTrue(a != b);
        }

        [TestMethod]
        public void MethodGetHashCode()
        {
            var matr = new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var a = new Matrix<int>(3, 3, matr);
            Assert.AreEqual(13000, a.GetHashCode());
        }
    }
}
