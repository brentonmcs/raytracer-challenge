using Xunit;

namespace rayTracer.xUnit
{
    public class LightsTest
    {
        [Fact]
        public void ALightHasPositionAndIntensity()
        {
            var intensity = new Color(1, 1, 1);
            var position = Tuple.Point(0, 0, 0);
            var light = new Light(position, intensity);

            Assert.Equal(position, light.Position);
            Assert.Equal(intensity, light.Intensity);
        }
    }
}