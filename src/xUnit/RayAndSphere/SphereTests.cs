using System;
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
            var xs = s.Intersections(r);

            Assert.Equal(2, xs.Count);
            Assert.Equal(3f, xs[0].T);
            Assert.Equal(7f, xs[1].T);
        }

        [Fact]
        public void IntersectingATranslatedSphereWithARay()
        {
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));
            var s = new Sphere {Transform = Matrix.Translation(5, 0, 0)};

            var xs = s.Intersections(r);
            Assert.Empty(xs);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 0, 1)]
        public void CalculateNormalOnASphereAtPoint(float x, float y, float z)
        {
            var s = new Sphere();
            var n = s.NormalAt(Tuple.Point(x, y, z));
            
            Assert.Equal(Tuple.Vector(x,y,z), n);
        }

        [Fact]
        public void CalculateAtANonAxialPoint()
        {
            var value = MathF.Sqrt(3) / 3;
            var s = new Sphere();
            var n = s.NormalAt(Tuple.Point(value, value, value));
            
            Assert.Equal(Tuple.Vector(value,value,value), n);
            Assert.Equal(Tuple.Vector(value,value,value), n.Normalise());
        }
        
        [Fact]
        public void CalculateTheNormalOnTranslatedSphere()
        {

            var s = new Sphere {Transform = Matrix.Translation(0, 1, 0)};
            
            var n = s.NormalAt(Tuple.Point(0, 1.70711f, -0.70711f));
        
            Assert.Equal(Tuple.Vector(0, 0.70711f, -0.70711f), n);
        }
        
        [Fact]
        public void CalculateTheNormalOnTransformedSphere()
        {
            var matrix = Matrix.Rotate_Z(MathF.PI / 5f).Scaling(1, 0.5f, 1);
            var s = new Sphere {Transform = matrix};
            
            var n = s.NormalAt(Tuple.Point(0, MathF.Sqrt(2) / 2f, -(MathF.Sqrt(2) / 2f)));
        
            Assert.Equal(Tuple.Vector(0, 0.97014f, -0.24254f), n);
        }

        [Fact]
        public void ASphereHasADefaultMaterial()
        {
            var s = new Sphere();
            var m = s.Material;
            
            Assert.Equal(new Material(), m );
        }
        
        [Fact]
        public void ASphereHasADefinedMaterial()
        {
            
            var s = new Sphere();
            var m = new Material
            {
                Ambient = 1
            };
            s.Material = m;
            
            Assert.Equal(m, s.Material  );
        }
            
    }
}