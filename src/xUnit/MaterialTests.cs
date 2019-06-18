using System;
using Xunit;

namespace rayTracer.xUnit
{
    public class MaterialTests
    {
        private readonly Material _m;
        private readonly Tuple _position;

        public MaterialTests()
        {
            _m = new Material();
            _position = Tuple.Point(0, 0, 0);
        }

        [Fact]
        public void TheDefaultMaterial()
        {
            var m = new Material();

            Assert.Equal(new Color(1, 1, 1), m.Color);
            Assert.Equal(0.1f, m.Ambient);
            Assert.Equal(0.9f, m.Diffuse);
            Assert.Equal(0.9f, m.Specular);
            Assert.Equal(200f, m.Shininess);
        }


        [Fact]
        public void LightingWithEyeBetweenTheLightAndTheSurface()
        {
            var eyeV = Tuple.Vector(0, 0, -1);
            var normalV = Tuple.Vector(0, 0, -1);
            var light = new Light(Tuple.Point(0, 0, -10), new Color(1, 1, 1));

            var result = _m.Lighting(light, _position, eyeV, normalV);

            Assert.Equal(new Color(1.9f, 1.9f, 1.9f), result);
        }

        [Fact]
        public void LightingWithEyeBetweenLightAndSurfaceEyeOffset45Deg()
        {
            var eyeV = Tuple.Vector(0, MathF.Sqrt(2) / 2, -MathF.Sqrt(2) / 2);
            var normalV = Tuple.Vector(0, 0, -1);
            var light = new Light(Tuple.Point(0, 0, -10), new Color(1, 1, 1));

            var result = _m.Lighting(light, _position, eyeV, normalV);

            Assert.Equal(new Color(1.0f, 1.0f, 1.0f), result);
        }

        [Fact]
        public void LightingWithEyeOppositeSurfaceLightOffset45Deg()
        {
            var eyeV = Tuple.Vector(0, 0, -1);
            var normalV = Tuple.Vector(0, 0, -1);
            var light = new Light(Tuple.Point(0, 10, -10), new Color(1, 1, 1));

            var result = _m.Lighting(light, _position, eyeV, normalV);

            Assert.Equal(new Color(0.7364f, 0.7364f, 0.7364f), result);
        }
        
        [Fact]
        public void LightingWithEyeInThePathOfReflection()
        {
            var eyeV = Tuple.Vector(0, -MathF.Sqrt(2) / 2, -MathF.Sqrt(2) / 2);
            var normalV = Tuple.Vector(0, 0, -1);
            var light = new Light(Tuple.Point(0, 10, -10), new Color(1, 1, 1));

            var result = _m.Lighting(light, _position, eyeV, normalV);

            Assert.Equal(new Color(1.6364f, 1.6364f, 1.6364f), result);
        }
        
        [Fact]
        public void LightingWithEyeBehindSurface()
        {
            var eyeV = Tuple.Vector(0, 0, -1);
            var normalV = Tuple.Vector(0, 0, -1);
            var light = new Light(Tuple.Point(0, 0, 10), new Color(1, 1, 1));

            var result = _m.Lighting(light, _position, eyeV, normalV);

            Assert.Equal(new Color(0.1f, 0.1f, 0.1f), result);
        }
    }
}