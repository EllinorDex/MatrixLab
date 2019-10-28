using NUnit.Framework;
using MatrixLib;

namespace MatrixLibTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstractOnesMatrixNorm()
        {
            Matrix<int> A = new Matrix<int>(5, 5, "ones");
            Assert.AreEqual(5, A.CountOfColumns);
            Assert.AreEqual(5, A.CountOfRows);

            Assert.AreEqual(1, A[2, 2]);
            Assert.AreEqual(0, A[3, 2]);
        }

        public void ConstractOnesMatrixRectangle()
        {
            Matrix<int> A = new Matrix<int>(5, 7, "ones");
            Assert.AreEqual(5, A.CountOfColumns);
            Assert.AreEqual(7, A.CountOfRows);

            Assert.AreEqual(1, A[2, 2]);
            Assert.AreEqual(0, A[5, 7]);
        }

        public void ConstractZerosMatrixNorm()
        {
            Matrix<int> A = new Matrix<int>(5, 7, "zeros");
            Assert.AreEqual(5, A.CountOfColumns);
            Assert.AreEqual(7, A.CountOfRows);

            for(int i = 0, j = 0; i < A.CountOfColumns && j < A.CountOfRows; ++i, ++j)
                Assert.AreEqual(0, A[i, j]);
        }
    }
}