using Xunit;

namespace rayTracer.xUnit.RayAndSphere
{
    public class RayTests
    {
        [Theory]
        [InlineData(0, 2, 3, 4)]
        [InlineData(1, 3, 3, 4)]
        [InlineData(-1, 1, 3, 4)]
        [InlineData(2.5f, 4.5f, 3, 4)]
        public void ComputingPointsFromADistance(float time, float x, float y, float z)
        {
            var ray = new Ray(Tuple.Point(2, 3, 4), Tuple.Vector(1, 0, 0));

            var point = ray.Position(time);

            Assert.Equal(Tuple.Point(x, y, z), point);
        }

        [Fact]
        public void CanCreateNew()
        {
            var origin = Tuple.Point(1, 2, 3);
            var direction = Tuple.Vector(4, 5, 6);

            var ray = new Ray(origin, direction);

            Assert.Equal(Tuple.Point(1, 2, 3), ray.Origin);
            Assert.Equal(Tuple.Vector(4, 5, 6), ray.Direction);
        }

        [Fact]
        public void ScalingARay()
        {
            var r = new Ray(Tuple.Point(1, 2, 3), Tuple.Vector(0, 1, 0));

            var m = Matrix.Identity.Scaling(2, 3, 4);

            var r2 = r.Transform(m);

            Assert.Equal(Tuple.Point(2, 6, 12), r2.Origin);
            Assert.Equal(Tuple.Vector(0, 3, 0), r2.Direction);
        }

        [Fact]
        public void TranslatingARay()
        {
            var r = new Ray(Tuple.Point(1, 2, 3), Tuple.Vector(0, 1, 0));

            var m = Matrix.Identity.Translation(3, 4, 5);

            var r2 = r.Transform(m);

            Assert.Equal(Tuple.Point(4, 6, 8), r2.Origin);
            Assert.Equal(Tuple.Vector(0, 1, 0), r2.Direction);
        }
    }
}