using System;
using Xunit;

namespace rayTracer.xUnit
{
    public class MatrixMovementTests
    {
        [Fact]
        public void MultiplyingByATranslationMatrix()
        {
            var transform = Matrix.Identity.Translation(5, -3, 2);
            var p = Tuple.Point(-3, 4, 5);

            var result = transform * p;
            Assert.Equal(Tuple.Point(2, 1, 7), result);
        }

        [Fact]
        public void MultiplyingByInverseTranslation()
        {
            var transform = Matrix.Identity.Translation(5, -3, 2);
            var inv = transform.Inverse();
            var p = Tuple.Point(-3, 4, 5);

            var result = inv * p;
            Assert.Equal(Tuple.Point(-8, 7, 3), result);
        }

        [Fact]
        public void MultiplyingByVector()
        {
            var transform = Matrix.Identity.Translation(5, -3, 2);
            var v = Tuple.Vector(-3, 4, 5);

            Assert.Equal(v, transform * v);
        }

        [Fact]
        public void ScalingMatrixAppliedToPoint()
        {
            var transform = Matrix.Identity.Scaling(2f, 3f, 4f);
            var p = Tuple.Point(-4, 6, 8);

            Assert.Equal(Tuple.Point(-8, 18, 32), transform * p);
        }

        [Fact]
        public void ScalingMatrixAppliedToVector()
        {
            var transform = Matrix.Identity.Scaling(2f, 3f, 4f);
            var p = Tuple.Vector(-4, 6, 8);

            Assert.Equal(Tuple.Vector(-8, 18, 32), transform * p);
        }

        [Fact]
        public void ScalingInverseMatrixAppliedToVector()
        {
            var transform = Matrix.Identity.Scaling(2f, 3f, 4f);
            var inv = transform.Inverse();
            var p = Tuple.Vector(-4, 6, 8);

            Assert.Equal(Tuple.Vector(-2, 2, 2), inv * p);
        }

        [Fact]
        public void Reflection()
        {
            var transform = Matrix.Identity.Scaling(-1, 1, 1);
            var p = Tuple.Point(2, 3, 4);

            Assert.Equal(Tuple.Point(-2, 3, 4), transform * p);
        }

        [Fact]
        public void RotationAroundX()
        {
            var p = Tuple.Point(0, 1, 0);

            var halfQuarter = Matrix.Identity.Rotate_X(MathF.PI / 4);
            var fullQuarter = Matrix.Identity.Rotate_X(MathF.PI / 2);

            Assert.Equal(Tuple.Point(0, MathF.Sqrt(2) / 2f, MathF.Sqrt(2) / 2f), halfQuarter * p);
            Assert.Equal(Tuple.Point(0, 0, 1), fullQuarter * p);
        }

        [Fact]
        public void RotationAroundXWithInverse()
        {
            var p = Tuple.Point(0, 1, 0);

            var halfQuarter = Matrix.Identity.Rotate_X(MathF.PI / 4);
            var inv = halfQuarter.Inverse();

            Assert.Equal(Tuple.Point(0, MathF.Sqrt(2) / 2f, -MathF.Sqrt(2) / 2f), inv * p);
        }

        [Fact]
        public void RotationAroundY()
        {
            var p = Tuple.Point(0, 0, 1);

            var halfQuarter = Matrix.Identity.Rotate_Y(MathF.PI / 4);
            var fullQuarter = Matrix.Identity.Rotate_Y(MathF.PI / 2);

            Assert.Equal(Tuple.Point(MathF.Sqrt(2) / 2f, 0, MathF.Sqrt(2) / 2f), halfQuarter * p);
            Assert.Equal(Tuple.Point(1, 0, 0), fullQuarter * p);
        }
        
        [Fact]
        public void RotationAroundYTo3()
        {
            var p = Tuple.Point(0, 0, 1);

            var fullQuarter = Matrix.Identity.Rotate_Y(MathF.PI / 2);

            var result = fullQuarter * p;
            Assert.Equal(Tuple.Point(1, 0, 0), result);
        }

        [Fact]
        public void RotationAroundZ()
        {
            var p = Tuple.Point(0, 1, 0);

            var halfQuarter = Matrix.Identity.Rotate_Z(MathF.PI / 4);
            var fullQuarter = Matrix.Identity.Rotate_Z(MathF.PI / 2);

            Assert.Equal(Tuple.Point(-MathF.Sqrt(2) / 2f, MathF.Sqrt(2) / 2f, 0), halfQuarter * p);
            Assert.Equal(Tuple.Point(-1, 0, 0), fullQuarter * p);
        }

        [Fact]
        public void ShearingProportionalXToY()
        {
            var transform = Matrix.Identity.Shearing(1f, 0f, 0f, 0f, 0f, 0f);
            var p = Tuple.Point(2, 3, 4);

            Assert.Equal(Tuple.Point(5, 3, 4), transform * p);
        }

        [Fact]
        public void ShearingProportionalXToZ()
        {
            var transform = Matrix.Identity.Shearing(0f, 1f, 0f, 0f, 0f, 0f);
            var p = Tuple.Point(2, 3, 4);

            Assert.Equal(Tuple.Point(6, 3, 4), transform * p);
        }

        [Fact]
        public void ShearingProportionalYToX()
        {
            var transform = Matrix.Identity.Shearing(0f, 0f, 1f, 0f, 0f, 0f);
            var p = Tuple.Point(2, 3, 4);

            Assert.Equal(Tuple.Point(2, 5, 4), transform * p);
        }

        [Fact]
        public void ShearingProportionalYToZ()
        {
            var transform = Matrix.Identity.Shearing(0f, 0f, 0f, 1f, 0f, 0f);
            var p = Tuple.Point(2, 3, 4);

            Assert.Equal(Tuple.Point(2, 7, 4), transform * p);
        }

        [Fact]
        public void ShearingProportionalZToX()
        {
            var transform = Matrix.Identity.Shearing(0f, 0f, 0f, 0f, 1f, 0f);
            var p = Tuple.Point(2, 3, 4);

            Assert.Equal(Tuple.Point(2, 3, 6), transform * p);
        }

        [Fact]
        public void ShearingProportionalZToY()
        {
            var transform = Matrix.Identity.Shearing(0f, 0f, 0f, 0f, 0f, 1f);
            var p = Tuple.Point(2, 3, 4);

            Assert.Equal(Tuple.Point(2, 3, 7), transform * p);
        }

        [Fact]
        public void ChainingTransformations()
        {
            var p = Tuple.Point(1, 0, 1);
            var a = Matrix.Identity.Rotate_X(MathF.PI / 2);
            var b = Matrix.Identity.Scaling(5, 5, 5);
            var c = Matrix.Identity.Translation(10, 5, 7);

            var p2 = a * p;
            Assert.Equal(Tuple.Point(1, -1, 0), p2);

            var p3 = b * p2;
            Assert.Equal(Tuple.Point(5, -5, 0), p3);

            var p4 = c * p3;
            Assert.Equal(Tuple.Point(15, 0, 7), p4);
        }

        [Fact]
        public void ChainingTransformations2()
        {
            var t =
                Matrix.Identity
                    .Rotate_X(MathF.PI / 2)
                    .Scaling(5, 5, 5)
                    .Translation(10, 5, 7);

            Assert.Equal(Tuple.Point(15, 0, 7), t * Tuple.Point(1, 0, 1));
        }
    }
}