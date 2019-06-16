using Xunit;

namespace rayTracer.xUnit.RayAndSphere
{
    public class RayTrackingIntersectionsTest
    {
        [Fact]
        public void AggregatingIntersections()
        {
            var s = new Sphere();

            var i1 = new Intersection(1, s);
            var i2 = new Intersection(2, s);

            var xs = IntersectionHelpers.Intersections(i1, i2);

            Assert.Equal(2, xs.Count);
            Assert.Equal(1, xs[0].T);
            Assert.Equal(2, xs[1].T);
        }

        [Fact]
        public void HitIsAlwaysLowestNonNegativeIntersection()
        {
            var s = new Sphere();
            var i1 = new Intersection(5, s);
            var i2 = new Intersection(7, s);
            var i3 = new Intersection(3, s);
            var i4 = new Intersection(2, s);

            var xs = IntersectionHelpers.Intersections(i1, i2, i3, i4);

            var i = xs.Hit();

            Assert.Equal(i4, i);
        }

        [Fact]
        public void HitWhenAllIntersectionsHaveNegativeT()
        {
            var s = new Sphere();
            var i1 = new Intersection(-2, s);
            var i2 = new Intersection(-2, s);

            var xs = IntersectionHelpers.Intersections(i1, i2);

            var i = xs.Hit();

            Assert.Null(i);
        }

        [Fact]
        public void HitWhenAllIntersectionsHavePositiveT()
        {
            var s = new Sphere();
            var i1 = new Intersection(1, s);
            var i2 = new Intersection(2, s);

            var xs = IntersectionHelpers.Intersections(i1, i2);

            var i = xs.Hit();

            Assert.Equal(i1, i);
        }

        [Fact]
        public void HitWhenSomeIntersectionsHaveNegativeT()
        {
            var s = new Sphere();
            var i1 = new Intersection(-1, s);
            var i2 = new Intersection(1, s);

            var xs = IntersectionHelpers.Intersections(i1, i2);

            var i = xs.Hit();

            Assert.Equal(i2, i);
        }

        [Fact]
        public void IntersectionEncapsulatesTAndObject()
        {
            var s = new Sphere();
            var i = new Intersection(3.5f, s);

            Assert.Equal(s, i.Object);
            Assert.Equal(3.5f, i.T);
        }
    }
}