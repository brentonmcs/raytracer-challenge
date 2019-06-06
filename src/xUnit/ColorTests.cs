using Xunit;

namespace rayTracer.xUnit
{
    public class ColorTests
    {
        [Fact]
        public void ColorChecks()
        {
            var colour = new Color(-0.5f, 0.4f, 1.7f);

            Assert.Equal(-0.5f, colour.Red);
            Assert.Equal(0.4f, colour.Green);
            Assert.Equal(1.7f, colour.Blue);
        }

        [Fact]
        public void AddColors()
        {
            var c1 = new Color(0.9f, 0.6f, 0.75f);
            var c2 = new Color(0.7f, 0.1f, 0.25f);

            Assert.Equal(new Color(1.6f, 0.7f, 1.0f), c1 + c2);
        }

        [Fact]
        public void SubtractColors()
        {
            var c1 = new Color(0.9f, 0.6f, 0.75f);
            var c2 = new Color(0.7f, 0.1f, 0.25f);

            Assert.Equal(new Color(0.2f, 0.5f, 0.5f), c1 - c2);
        }

        [Fact]
        public void MultiplyColorsByScalar()
        {
            var c1 = new Color(0.2f, 0.3f, 0.4f);

            Assert.Equal(new Color(0.4f, 0.6f, 0.8f), c1 * 2);
        }
        
        [Fact]
        public void MultiplyColors()
        {
            var c1 = new Color(1f, 0.2f, 0.4f);
            var c2 = new Color(0.9f, 1f, 0.1f);

            Assert.Equal(new Color(0.9f, 0.2f, 0.04f), c1 * c2);
        }
        
        [Fact]
        public void ScaleColor()
        {
            var c = new Color(0,0.5f,0);
            Assert.Equal("0 128 0", c.ScaledString.Trim());
        }
    }
}