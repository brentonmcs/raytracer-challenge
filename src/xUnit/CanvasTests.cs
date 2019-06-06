using Xunit;
using Xunit.Abstractions;

namespace rayTracer.xUnit
{
    public class CanvasTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CanvasTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void CreateCanvas()
        {
            var c = new Canvas(10, 20);

            Assert.Equal(10, c.Width);
            Assert.Equal(20, c.Height);

            for (var h = 0; h < 20; h++)
            {
                for (var w = 0; w < 10; w++)
                {
                    Assert.Equal(new Color(0, 0, 0), c.GetColor(w, h));
                }
            }
        }


        [Fact]
        public void WriteColor()
        {
            var c = new Canvas(10, 20);
            var red = new Color(1, 0, 0);

            c.WriteColor(2, 3, red);

            Assert.Equal(red, c.GetColor(2, 3));
        }

        [Fact]
        public void CheckPPMHeader()
        {
            var c = new Canvas(5, 3);
            var lines = c.CreatePPMLines().Split("\n");

            Assert.True(lines.Length >= 3);
            Assert.Equal("P3", lines[0]);
            Assert.Equal("5 3", lines[1]);
            Assert.Equal("255", lines[2]);
        }

        [Fact]
        public void CheckPPMBody()
        {
            var c = new Canvas(5, 3);
            var c1 = new Color(1.5f, 0, 0);
            var c2 = new Color(0f, 0.5f, 0);
            var c3 = new Color(-0.5f, 0f, 1f);

            c.WriteColor(0, 0, c1);
            c.WriteColor(2, 1, c2);
            c.WriteColor(4, 2, c3);

            var lines = c.CreatePPMLines().Split("\n");

            Assert.Equal(7, lines.Length);

            Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", lines[3]);
            Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", lines[4]);
            Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", lines[5]);
        }

        [Fact]
        public void CheckLineLength()
        {
            var width = 10;
            var height = 2;
            var c = new Canvas(width, height);
            var c1 = new Color(1, 0.8f, 0.6f);

            for (var h = 0; h < height; h++)
            {
                for (var w = 0; w < width; w++)
                {
                    c.WriteColor(w, h, c1);
                }
            }
            var ppmLines = c.CreatePPMLines();
            var lines = ppmLines.Split("\n");
            
            Assert.Equal(8, lines.Length);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[3]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[4]);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[5]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[6]);
        }
        
        [Fact]
        public void CheckLineLength2()
        {
            const int width = 50;
            const int height = 1;
            var c = new Canvas(width, height);
            var c1 = new Color(1, 0.8f, 0.6f);

            for (var h = 0; h < height; h++)
            {
                for (var w = 0; w < width; w++)
                {
                    c.WriteColor(w, h, c1);
                }
            }
            var ppmLines = c.CreatePPMLines();
            var lines = ppmLines.Split("\n");

            _testOutputHelper.WriteLine(ppmLines);
            foreach (var line in lines)
            {
                Assert.True(line.Length <= 70);
            }
        }
    }
}