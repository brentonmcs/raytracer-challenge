using Xunit;

namespace rayTracer.xUnit
{
    public class IntersectingRaysWithSpheres
    {
        [Fact]
        public void ARayIntersectsASphereWithTwoPoints()
        {
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = s.Intersections(r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(4f, intersections[0]);
            Assert.Equal(6f, intersections[1]);
        }

        [Fact]
        public void ARayIntersectsASphereAtATangent()
        {
            var r = new Ray(Tuple.Point(0, 1, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = s.Intersections(r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(5f, intersections[0]);
            Assert.Equal(5f, intersections[1]);
        }

        [Fact]
        public void ARayMissesASphere()
        {
            var r = new Ray(Tuple.Point(0, 2, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = s.Intersections(r);

            Assert.Empty(intersections);
        }
        
        [Fact]
        public void ARayOriginatesInsideASphere()
        {
            var r = new Ray(Tuple.Point(0, 0, 0), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = s.Intersections(r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(-1f, intersections[0]);
            Assert.Equal(1f, intersections[1]);
        }
        
        [Fact]
        public void ASphereIsBehindARay()
        {
            var r = new Ray(Tuple.Point(0, 0, 5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = s.Intersections(r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(-6f, intersections[0]);
            Assert.Equal(-4f, intersections[1]);
        }
    }
}