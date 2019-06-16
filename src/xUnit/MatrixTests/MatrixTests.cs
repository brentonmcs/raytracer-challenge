using Xunit;

namespace rayTracer.xUnit.MatrixTests
{
    public class MatrixTests
    {
        [Fact]
        public void BasicEqualityCheck()
        {
            var v1 = new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2};
            var v2 = new[] {1f, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2};

            Assert.Equal(v1, v2);
        }

        [Fact]
        public void CalculateCofactors()
        {
            var m = new Matrix(3, 3, new[] {3f, 5, 0, 2, -1, -7, 6, -1, 5});

            Assert.Equal(-12, m.Minor(0, 0));

            Assert.Equal(-12, m.Cofactor(0, 0));
            Assert.Equal(25, m.Minor(1, 0));
            Assert.Equal(-25, m.Cofactor(1, 0));
        }

        [Fact]
        public void CalculateDeterminant2X2()
        {
            var m1 = new Matrix(2, 2, new[] {1f, 5, -3, 2});

            Assert.Equal(17f, m1.Determinant);
        }

        [Fact]
        public void CalculateDeterminantOf3X3()
        {
            var m = new Matrix(3, 3, new[] {1f, 2, 6, -5, 8, -4, 2, 6, 4});

            Assert.Equal(56, m.Cofactor(0, 0));
            Assert.Equal(12, m.Cofactor(0, 1));
            Assert.Equal(-46, m.Cofactor(0, 2));

            Assert.Equal(-196, m.Determinant);
        }

        [Fact]
        public void CalculateDeterminantOf4X4()
        {
            var m = new Matrix(4, 4, new[] {-2f, -8, 3, 5, -3, 1, 7, 3, 1, 2, -9, 6, -6, 7, 7, -9});

            Assert.Equal(690, m.Cofactor(0, 0));
            Assert.Equal(447, m.Cofactor(0, 1));
            Assert.Equal(210, m.Cofactor(0, 2));
            Assert.Equal(51, m.Cofactor(0, 3));

            Assert.Equal(-4071, m.Determinant);
        }

        [Fact]
        public void CalculateInverseMatrix()
        {
            var m = new Matrix(4, 4, new[]
            {
                -5f, 2, 6, -8,
                1, -5, 1, 8,
                7, 7, -6, -7,
                1, -3, 7, 4
            });

            var mI = m.Inverse();
            Assert.Equal(532, m.Determinant);

            Assert.Equal(-160, m.Cofactor(2, 3));
            Assert.Equal(-160f / 532f, mI[3, 2]);

            Assert.Equal(105, m.Cofactor(3, 2));
            Assert.Equal(105f / 532f, mI[2, 3]);

            var expectedMatrix = new Matrix(4, 4, new[]
            {
                0.21805f, 0.45113f, 0.24060f, -0.04511f,
                -0.80827f, -1.45677f, -0.44361f, 0.52068f,
                -0.07895f, -0.22368f, -0.05263f, 0.19737f,
                -0.52256f, -0.81391f, -0.30075f, 0.30639f
            });

            Assert.Equal(expectedMatrix, mI);
        }

        [Fact]
        public void CalculateInverseMatrix2()
        {
            var m = new Matrix(4, 4, new[]
            {
                8f, -5, 9, 2,
                7, 5, 6, 1,
                -6, 0, 9, 6,
                -3, 0, -9, -4
            });

            var mI = m.Inverse();

            var expectedMatrix = new Matrix(4, 4, new[]
            {
                -0.15385f, -0.15385f, -0.28205f, -0.53846f,
                -0.07692f, 0.12308f, 0.02564f, 0.03077f,
                0.35897f, 0.35897f, 0.43590f, 0.92308f,
                -0.69231f, -0.69231f, -0.76923f, -1.92308f
            });

            Assert.Equal(expectedMatrix, mI);
        }

        [Fact]
        public void CalculateInverseMatrix3()
        {
            var m = new Matrix(4, 4, new[]
            {
                9f, 3, 0, 9,
                -5, -2, -6, -3,
                -4, 9, 6, 4,
                -7, 6, 6, 2
            });

            var mI = m.Inverse();

            var expectedMatrix = new Matrix(4, 4, new[]
            {
                -0.04074f, -0.07778f, 0.14444f, -0.22222f,
                -0.07778f, 0.03333f, 0.36667f, -0.33333f,
                -0.02901f, -0.14630f, -0.10926f, 0.12963f,
                0.17778f, 0.06667f, -0.26667f, 0.33333f
            });

            Assert.Equal(expectedMatrix, mI);
        }

        [Fact]
        public void CalculateMinor()
        {
            var m = new Matrix(3, 3, new[] {3f, 5, 0, 2, -1, -7, 6, -1, 5});

            Assert.Equal(25, m.SubMatrix(1, 0).Determinant);

            Assert.Equal(25, m.Minor(1, 0));
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
        public void GetSubMatrixOf3X3()
        {
            var m = new Matrix(3, 3, new[] {1f, 5, 0, -3, 2, 7, 0, 6, -3});

            var mR = m.SubMatrix(0, 2);

            Assert.Equal(new Matrix(2, 2, new[] {-3f, 2, 0, 6}), mR);
        }

        [Fact]
        public void GetSubMatrixOf4X4()
        {
            var m = new Matrix(4, 4, new[] {-6f, 1, 1, 6, -8, 5, 8, 6, -1, 0, 8, 2, -7, 1, -1, 1});

            var mR = m.SubMatrix(2, 1);

            Assert.Equal(new Matrix(3, 3, new[] {-6f, 1, 6, -8, 8, 6, -7, -1, 1}), mR);
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
        public void MatrixMultiplicationByIdentity()
        {
            var mA = new Matrix(4, 4, new[] {0f, 1, 2, 4, 1, 2, 4, 8, 2, 4, 8, 16, 4, 8, 16, 32});
            Assert.Equal(mA, mA * Matrix.Identity);
        }

        [Fact]
        public void MatrixTupleMultiplication()
        {
            var mA = new Matrix(4, 4, new[] {1f, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 0, 1});
            var t = new Tuple(1, 2, 3, 1);

            Assert.Equal(new Tuple(18, 24, 33, 1), mA * t);
        }

        [Fact]
        public void MatrixTupleMultiplicationByIdentity()
        {
            var t = new Tuple(1, 2, 3, 4);

            Assert.Equal(t, Matrix.Identity * t);
        }

        [Fact]
        public void TestingIfMatrixIsInvertible()
        {
            var m = new Matrix(4, 4, new[] {6f, 4, 4, 4, 5, 5, 7, 6, 4, -9, 3, -7, 9, 1, 7, -6});

            Assert.Equal(-2120, m.Determinant);

            Assert.True(m.Invertible);
        }

        [Fact]
        public void TestingIfMatrixIsNotInvertible()
        {
            var m = new Matrix(4, 4, new[] {-4f, 2, -2, -3, 9, 6, 2, 6, 0, -5, 1, -5, 0, 0, 0, 0});

            Assert.Equal(0, m.Determinant);

            Assert.False(m.Invertible);
        }

        [Fact]
        public void TestInverseMatrixEqualsMultiplied()
        {
            var mA = new Matrix(4, 4, new[]
            {
                3f, -9, 7, 3,
                -3, -8, 2, -9,
                -4, 4, 4, 1,
                -6, 5, 1, 1
            });

            var mB = new Matrix(4, 4, new[]
            {
                8f, 2, 2, 2,
                3, -1, 7, 0,
                7, 0, 5, 4,
                -6, 2, 0, 5
            });

            var mC = mA * mB;

            Assert.Equal(mA, mC * mB.Inverse());
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
    }
}