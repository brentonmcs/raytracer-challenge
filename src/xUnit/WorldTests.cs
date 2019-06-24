using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace rayTracer.xUnit
{
    public class WorldTests
    {
        [Fact]
        public void CreatingAWorld()
        {
            var w = new World();

            Assert.Empty(w.Objects);
            Assert.Null(w.Light);
        }

        [Fact]
        public void TheDefaultWorld()
        {
            var light = new Light(Tuple.Point(-10, 10, -10), new Color(1, 1, 1));

            var s1 = new Sphere
            {
                Material = new Material
                {
                    Color = new Color(0.8f, 1, 0.6f),
                    Diffuse = 0.7f,
                    Specular = 0.2f
                }
            };

            var s2 = new Sphere
            {
                Transform = Matrix.Scaling(0.5f, 0.5f, 0.5f)
            };

            var w = DefaultWorld();

            Assert.Equal(light, w.Light.First());

            Assert.Contains(w.Objects, x => x.Equals(s1));
            Assert.Contains(w.Objects, x => x.Equals(s2));
        }

        [Fact]
        public void IntersectAWorldWithARay()
        {
            var w = DefaultWorld();
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));

            var xs = w.Intersect(r);

            Assert.Equal(4, xs.Count);
            Assert.Equal(4, xs[0].T);
            Assert.Equal(4.5, xs[1].T);
            Assert.Equal(5.5, xs[2].T);
            Assert.Equal(6, xs[3].T);
        }


        [Fact]
        public void ShadingAnIntersection()
        {
            var w = DefaultWorld();
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));

            var shape = w.Objects.First();
            var i = new Intersection(4, shape);

            var comps = new Computation(i, r);

            var c = w.ShadeHit(comps);

            Assert.Equal(new Color(0.38066f, 0.47583f, 0.2855f), c);
        }


        [Fact]
        public void ShadingAnIntersectionFromTheInside()
        {
            var w = DefaultWorld();
            w.Light = new List<Light> {new Light(Tuple.Point(0, 0.25f, 0), new Color(1, 1, 1))};

            var r = new Ray(Tuple.Point(0, 0, 0), Tuple.Vector(0, 0, 1));

            var shape = w.Objects[1];
            var i = new Intersection(0.5f, shape);

            var comps = new Computation(i, r);

            var c = w.ShadeHit(comps);
            Assert.Equal(new Color(0.90498f, 0.90498f, 0.90498f), c);
        }

        [Fact]
        public void TheColorWhenARayMisses()
        {
            var w = DefaultWorld();
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 1, 0));

            var c = w.ColorAt(r);
            
            Assert.Equal(new Color(0,0,0),c );
        }
        
        
        [Fact]
        public void TheColorWhenARayHits()
        {
            var w = DefaultWorld();
            var r = new Ray(Tuple.Point(0, 0, -5), Tuple.Vector(0, 0, 1));

            var c = w.ColorAt(r);
            
            Assert.Equal(new Color(0.38066f, 0.47583f, 0.2855f), c);
        }
        
        [Fact]
        public void TheColorWithAnIntersectionBehindTheRay()
        {
            var w = DefaultWorld();
            var outer = w.Objects[0];
            outer.Material.Ambient = 1;
            var inner = w.Objects[1];
            inner.Material.Ambient = 1;
                
            var r = new Ray(Tuple.Point(0, 0, 0.75f), Tuple.Vector(0, 0, -1));

            var c = w.ColorAt(r);
            
            Assert.Equal(inner.Material.Color, c);
        }

        private static World DefaultWorld()
        {
            var light = new Light(Tuple.Point(-10, 10, -10), new Color(1, 1, 1));

            var s1 = new Sphere
            {
                Material = new Material
                {
                    Color = new Color(0.8f, 1, 0.6f),
                    Diffuse = 0.7f,
                    Specular = 0.2f
                }
            };

            var s2 = new Sphere
            {
                Transform = Matrix.Scaling(0.5f, 0.5f, 0.5f)
            };

            return new World
            {
                Light = new List<Light> { light},
                Objects = new List<Sphere>
                {
                    s1, s2
                }
            };
        }
    }
}