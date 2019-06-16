using Xunit;

namespace rayTracer.xUnit.TupleAndVectors
{
    public class TupleOperations
    {
        [Fact]
        public void AddingTwoTuples()
        {
            var tuple1 = new Tuple(3, -2, 5, 1);
            var tuple2 = new Tuple(-2, 3, 1, 0);

            var result = tuple1 + tuple2;

            Assert.Equal(new Tuple(1f, 1f, 6f, 1), result);
        }

        [Fact]
        public void DivideTuple()
        {
            var tuple1 = new Tuple(1, -2, 3, -4);

            Assert.Equal(new Tuple(0.5f, -1, 1.5f, -2), tuple1 / 2);
        }

        [Fact]
        public void MultiplyByFraction()
        {
            var tuple1 = new Tuple(1, -2, 3, -4);

            Assert.Equal(new Tuple(0.5f, -1, 1.5f, -2), tuple1 * 0.5f);
        }

        [Fact]
        public void MultiplyByScalar()
        {
            var tuple1 = new Tuple(1, -2, 3, -4);

            Assert.Equal(new Tuple(3.5f, -7, 10.5f, -14), tuple1 * 3.5f);
        }

        [Fact]
        public void NegateTuple()
        {
            var tuple1 = new Tuple(1, -2, 3, -4);

            Assert.Equal(new Tuple(-1, 2, -3, 4), !tuple1);
        }

        [Fact]
        public void SubtractingTwoTuples()
        {
            var tuple1 = Tuple.Point(3, 2, 1);
            var tuple2 = Tuple.Point(5, 6, 7);

            var result = tuple1 - tuple2;

            Assert.Equal(Tuple.Vector(-2f, -4f, -6f), result);
        }

        [Fact]
        public void SubtractingTwoTuples2()
        {
            var tuple1 = Tuple.Point(3, 2, 1);
            var tuple2 = Tuple.Vector(5, 6, 7);

            var result = tuple1 - tuple2;

            Assert.Equal(Tuple.Point(-2f, -4f, -6f), result);
        }

        [Fact]
        public void SubtractingTwoTuples3()
        {
            var tuple1 = Tuple.Vector(3, 2, 1);
            var tuple2 = Tuple.Vector(5, 6, 7);

            var result = tuple1 - tuple2;

            Assert.Equal(Tuple.Vector(-2f, -4f, -6f), result);
        }
    }
}