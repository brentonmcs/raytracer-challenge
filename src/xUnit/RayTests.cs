using Xunit;

namespace rayTracer.xUnit
{
    public class RayTests
    {
        [Fact]
        public void CanCreateNew()
        {
            var origin = Tuple.Point(1, 2, 3);
            var direction = Tuple.Vector(4, 5, 6);
            
            var ray = new Ray(origin, direction);
            
            Assert.Equal(Tuple.Point(1,2,3), ray.Origin);
            Assert.Equal(Tuple.Vector(4,5,6), ray.Direction);
        }

        [Theory]
        [InlineData(0, 2, 3, 4)]
        [InlineData(1, 3, 3, 4)]
        [InlineData(-1, 1, 3, 4)]
        [InlineData(2.5f, 4.5f, 3, 4)]
        public void ComputingPointsFromADistance(float time, float x, float y, float z)
        {
            var ray = new Ray(Tuple.Point(2,3,4), Tuple.Vector(1,0,0));

            var point = ray.Position(time);
            
            Assert.Equal(Tuple.Point(x,y,z), point);
        }
    }
}