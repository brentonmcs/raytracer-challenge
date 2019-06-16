using Xunit;

namespace rayTracer.xUnit.RayAndSphere
{
    public class RaysIntersectingWithSpheres
    {
        [Fact]
        public void ARayIntersectsASphereAtATangent()
        {
            var r = new Ray(Tuple.Point(0, 1, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = IntersectionHelpers.Intersections(s, r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(5f, intersections[0].T);
            Assert.Equal(5f, intersections[1].T);
        }

        [Fact]
        public void ARayIntersectsASphereWithTwoPoints()
        {
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = IntersectionHelpers.Intersections(s, r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(4f, intersections[0].T);
            Assert.Equal(s, intersections[0].Object);

            Assert.Equal(6f, intersections[1].T);
            Assert.Equal(s, intersections[1].Object);
        }

        [Fact]
        public void ARayMissesASphere()
        {
            var r = new Ray(Tuple.Point(0, 2, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = IntersectionHelpers.Intersections(s, r);

            Assert.Empty(intersections);
        }

        [Fact]
        public void ARayOriginatesInsideASphere()
        {
            var r = new Ray(Tuple.Point(0, 0, 0), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = IntersectionHelpers.Intersections(s, r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(-1f, intersections[0].T);
            Assert.Equal(1f, intersections[1].T);
        }

        [Fact]
        public void ASphereIsBehindARay()
        {
            var r = new Ray(Tuple.Point(0, 0, 5), Tuple.Vector(0, 0, 1));
            var s = new Sphere();

            var intersections = IntersectionHelpers.Intersections(s, r);

            Assert.Equal(2, intersections.Count);
            Assert.Equal(-6f, intersections[0].T);
            Assert.Equal(-4f, intersections[1].T);
        }
    }
}