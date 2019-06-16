using Xunit;

namespace rayTracer.xUnit.TupleAndVectors
{
    public class TupleTests
    {
        [Fact]
        public void ATupleFactoryPoint()
        {
            var tuple = Tuple.Point(4.3f, -4.2f, 3.1f);

            Assert.Equal(4.3f, tuple.X);
            Assert.Equal(-4.2f, tuple.Y);
            Assert.Equal(3.1f, tuple.Z);
            Assert.Equal(1, tuple.W);
            Assert.True(tuple.IsPoint);
            Assert.False(tuple.IsVector);
        }

        [Fact]
        public void ATupleFactoryVectorsAVector()
        {
            var tuple = Tuple.Vector(4.3f, -4.2f, 3.1f);

            Assert.Equal(4.3f, tuple.X);
            Assert.Equal(-4.2f, tuple.Y);
            Assert.Equal(3.1f, tuple.Z);
            Assert.Equal(0, tuple.W);
            Assert.False(tuple.IsPoint);
            Assert.True(tuple.IsVector);
        }

        [Fact]
        public void ATupleWithW0IsAVector()
        {
            var tuple = new Tuple(4.3f, -4.2f, 3.1f, 0);

            Assert.Equal(4.3f, tuple.X);
            Assert.Equal(-4.2f, tuple.Y);
            Assert.Equal(3.1f, tuple.Z);
            Assert.Equal(0, tuple.W);
            Assert.False(tuple.IsPoint);
            Assert.True(tuple.IsVector);
        }

        [Fact]
        public void ATupleWithW1IsAPoint()
        {
            var tuple = new Tuple(4.3f, -4.2f, 3.1f, 1);

            Assert.Equal(4.3f, tuple.X);
            Assert.Equal(-4.2f, tuple.Y);
            Assert.Equal(3.1f, tuple.Z);
            Assert.Equal(1, tuple.W);
            Assert.True(tuple.IsPoint);
            Assert.False(tuple.IsVector);
        }


        [Fact]
        public void TwoTuplesShouldEqualEachOther()
        {
            var tuple1 = Tuple.Vector(3f, 2.1f, -12.2f);
            var tuple2 = Tuple.Vector(3f, 2.1f, -12.2f);

            Assert.Equal(tuple1, tuple2);
        }

        [Fact]
        public void TwoTuplesShouldNotEqualEachOther()
        {
            var tuple1 = Tuple.Vector(3f, 2.1f, -12.2f);
            var tuple2 = Tuple.Vector(3f, 2.1f, -12f);

            Assert.NotEqual(tuple1, tuple2);
        }

        [Fact]
        public void TwoTuplesShouldNotEqualEachOther2()
        {
            var tuple1 = new Tuple(3f, 2.1f, -12.2f, 0);
            var tuple2 = new Tuple(3f, 2.1f, -12.2f, 1);

            Assert.NotEqual(tuple1, tuple2);
        }

        [Fact]
        public void TwoTuplesShouldNotEqualEachOther3()
        {
            var tuple1 = new Tuple(3f, 2.1f, -12.2f, 1);
            var tuple2 = new Tuple(3.1f, 2.1f, -12.2f, 1);

            Assert.NotEqual(tuple1, tuple2);
        }

        [Fact]
        public void TwoTuplesShouldNotEqualEachOther4()
        {
            var tuple1 = new Tuple(3f, 2.101f, -12.2f, 1);
            var tuple2 = new Tuple(3f, 2.1f, -12.2f, 1);

            Assert.NotEqual(tuple1, tuple2);
        }
    }
}