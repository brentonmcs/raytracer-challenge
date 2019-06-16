using Xunit;

namespace rayTracer.xUnit.RayAndSphere
{
    public class SphereTests
    {
        [Fact]
        public void SphereDefaultTransform()
        {
            var s = new Sphere();

            Assert.Equal(Matrix.Identity, s.Transform);
        }

        [Fact]
        public void ChangingSpheresTransform()
        {
            var s = new Sphere();
            var t = Matrix.Translation(2, 3, 4);
            s.Transform = t;
            Assert.Equal(t, s.Transform);
        }

        [Fact]
        public void IntersectingScaledSphereWithARay()
        {
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));

            var s = new Sphere {Transform = Matrix.Scaling(2, 2, 2)};
            var xs = IntersectionHelpers.Intersections(s, r);

            Assert.Equal(2, xs.Count);
            Assert.Equal(3f, xs[0].T);
            Assert.Equal(7f, xs[1].T);
        }

        [Fact]
        public void IntersectingATranslatedSphereWithARay()
        {
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere {Transform = Matrix.Translation(5, 0, 0)};

            var xs = IntersectionHelpers.Intersections(s, r);
            Assert.Empty(xs);
        }
    }
}