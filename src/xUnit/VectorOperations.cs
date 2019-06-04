using System;
using Xunit;

namespace rayTracer.xUnit
{
    public class VectorOperationsTests
    {
        [Fact]
        public void MagnitudeSimple()
        {
            var tuple = Tuple.Vector(1, 0, 0);

            Assert.Equal(1, tuple.Magnitude());
        }

        [Fact]
        public void MagnitudeHard()
        {
            var tuple = Tuple.Vector(1, 2, 3);

            Assert.Equal(MathF.Sqrt(14), tuple.Magnitude());
        }

        [Fact]
        public void MagnitudeHard2()
        {
            var tuple = Tuple.Vector(-1, -2, -3);

            Assert.Equal(MathF.Sqrt(14), tuple.Magnitude());
        }

        [Fact]
        public void Normalise()
        {
            var tuple = Tuple.Vector(4, 0, 0);

            Assert.Equal(Tuple.Vector(1, 0, 0), tuple.Normalise());
        }

        [Fact]
        public void NormaliseHarder()
        {
            var tuple = Tuple.Vector(1, 2, 3);    

            Assert.Equal( Tuple.Vector(1 / MathF.Sqrt(14), 2 / MathF.Sqrt(14), 3 / MathF.Sqrt(14)),
                tuple.Normalise());
        }
        
        [Fact]
        public void DotProduct()
        {
            var tuple = Tuple.Vector(1, 2, 3);
            var tuple2 = Tuple.Vector(2, 3,4);

            Assert.Equal(20, VectorOperations.Dot(tuple, tuple2));
        }

        [Fact]
        public void CrossProduct()
        {
            var tuple = Tuple.Vector(1, 2, 3);
            var tuple2 = Tuple.Vector(2, 3,4);
            
            Assert.Equal(Tuple.Vector(-1, 2, -1), VectorOperations.Cross(tuple, tuple2));
            Assert.Equal(Tuple.Vector(1, -2, 1), VectorOperations.Cross(tuple2, tuple));
        }
    }
}