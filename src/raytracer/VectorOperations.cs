using System;

namespace rayTracer
{
    public static class VectorOperations
    {
        public static float Magnitude(this Tuple t)
        {
            var squares = MathF.Pow(t.X, 2) + MathF.Pow(t.Y, 2) + MathF.Pow(t.Z, 2);
            return MathF.Sqrt(squares);
        }
        
        public static float Dot(Tuple tuple, Tuple tuple2) =>
            tuple.X * tuple2.X +
            tuple.Y * tuple2.Y +
            tuple.Z * tuple2.Z +
            tuple.W * tuple2.W;

        public static Tuple Cross(Tuple t1, Tuple t2)
        {
            return Tuple.Vector(t1.Y * t2.Z - t1.Z * t2.Y, t1.Z * t2.X - t1.X * t2.Z, t1.X * t2.Y - t1.Y * t2.X);
        }
    }
}