using Xunit;

namespace rayTracer.xUnit
{
    public class MatrixTests
    {
        [Fact]
        public void ConstructAndInspectMatrix4X4()
        {
            var m = new Matrix(4, 4,
                new[] {1, 2, 3, 4, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f});

            Assert.Equal(1, m[0, 0]);
            Assert.Equal(4, m[0, 3]);
            Assert.Equal(5.5, m[1, 0]);
            Assert.Equal(7.5, m[1, 2]);
            Assert.Equal(11, m[2, 2]);
            Assert.Equal(13.5, m[3, 0]);
            Assert.Equal(15.5, m[3, 2]);
        }

        [Fact]
        public void ConstructAndInspectMatrix2X2()
        {
            var m = new Matrix(2, 2,
                new[] {-3, 5, 1, -2f});

            Assert.Equal(-3, m[0, 0]);
            Assert.Equal(5, m[0, 1]);
            Assert.Equal(1, m[1, 0]);
            Assert.Equal(-2, m[1, 1]);
        }


        [Fact]
        public void ConstructAndInspectMatrix3X3()
        {
            var m = new Matrix(3, 3,
                new[] {-3, 5, 0, 1, -2f, -7, 0, 1, 1});

            Assert.Equal(-3, m[0, 0]);
            Assert.Equal(5, m[0, 1]);
            Assert.Equal(0, m[0, 2]);
            Assert.Equal(1, m[1, 0]);
            Assert.Equal(-2, m[1, 1]);
            Assert.Equal(-7, m[1, 2]);

            Assert.Equal(0, m[2, 0]);
            Assert.Equal(1, m[2, 1]);
            Assert.Equal(1, m[2, 2]);
        }

        [Fact]
        public void BasicEqualityCheck()
        {
            var v1 = new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2};
            var v2 = new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2};

            Assert.Equal(v1, v2);
        }

        [Fact]
        public void MatricesAreEqual()
        {
            var mA = new Matrix(4, 4, new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2});
            var mB = new Matrix(4, 4, new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2});

            Assert.Equal(mA, mB);
        }

        [Fact]
        public void MatricesAreNotEqual()
        {
            var mA = new Matrix(4, 4, new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2});
            var mB = new Matrix(4, 4, new[] {2f, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 1});

            Assert.NotEqual(mA, mB);
        }

        [Fact]
        public void MatrixMultiplication()
        {
            var mA = new Matrix(4, 4, new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2});
            var mB = new Matrix(4, 4, new[] {-2f, 1, 2, 3, 3, 2, 1, -1, 4, 3, 6, 5, 1, 2, 7, 8});

            var mResult = new Matrix(4, 4, new[] {20f, 22, 50, 48, 44, 54, 114, 108, 40, 58, 110, 102, 16, 26, 46, 42});
            Assert.Equal(mResult, mA * mB);
        }

        [Fact]
        public void MatrixTupleMultiplication()
        {
            var mA = new Matrix(4, 4, new[] {1f, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 0, 1});
            var t = new Tuple(1, 2, 3, 1);

            Assert.Equal(new Tuple(18, 24, 33, 1), mA * t);
        }

        [Fact]
        public void MatrixMultiplicationByIdentity()
        {
            var mA = new Matrix(4, 4, new[] {0f, 1, 2, 4, 1, 2, 4, 8, 2, 4, 8, 16, 4, 8, 16, 32});
            Assert.Equal(mA, mA * Matrix.Identity);
        }

        [Fact]
        public void MatrixTupleMultiplicationByIdentity()
        {
            var t = new Tuple(1, 2, 3, 4);

            Assert.Equal(t, Matrix.Identity * t);
        }

        [Fact]
        public void TransposeMatrix()
        {
            var mA = new Matrix(4, 4, new[] {0f, 9, 3, 0, 9, 8, 0, 8, 1, 8, 5, 3, 0, 0, 5, 8});
            var mR = new Matrix(4, 4, new[] {0f, 9, 1, 0, 9, 8, 8, 0, 3, 0, 5, 5, 0, 8, 3, 8});

            Assert.Equal(mR, mA.Transpose());
        }

        [Fact]
        public void TransposeMatrixIdentity()
        {
            Assert.Equal(Matrix.Identity, Matrix.Identity.Transpose());
        }

        [Fact]
        public void CalculateDeterminant2X2()
        {
            var m1 = new Matrix(2, 2, new[] {1f, 5, -3, 2});

            Assert.Equal(17f, m1.Determinant);
        }

        [Fact]
        public void GetSubMatrixOf3X3()
        {
            var m = new Matrix(3, 3, new[] {1f, 5, 0, -3, 2, 7, 0, 6, -3});

            var mR = m.SubMatrix(0, 2);

            Assert.Equal(new Matrix(2, 2, new[] {-3f, 2, 0, 6}), mR);
        }

        [Fact]
        public void GetSubMatrixOf4X4()
        {
            var m = new Matrix(4, 4, new[] {-6f, 1, 1, 6, -8, 5, 8, 6, -1,0,8,2,-7,1,-1,1});

            var mR = m.SubMatrix(2, 1);

            Assert.Equal(new Matrix(3, 3, new[] {-6f, 1, 6, -8,8,6,-7,-1,1}), mR);
        }
    }
}