using rayTracer.Helpers;

namespace rayTracer
{
    public class Tuple
    {
        private static readonly Tuple Zero = new Tuple(0, 0, 0, 0);

        public Tuple(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public float W { get; set; }

        public bool IsVector => W.Equals(0);

        public bool IsPoint => W.Equals(1);

        public static Tuple operator +(Tuple t1, Tuple t2)
        {
            return new Tuple(t1.X + t2.X, t1.Y + t2.Y, t1.Z + t2.Z, t1.W + t2.W);
        }

        public static Tuple Vector(float x, float y, float z)
        {
            return new Tuple(x, y, z, 0);
        }

        public static Tuple Point(float x, float y, float z)
        {
            return new Tuple(x, y, z, 1);
        }

        public Tuple Normalise()
        {
            return this / this.Magnitude();
        }

        public static Tuple operator !(Tuple t2)
        {
            return Zero - t2;
        }

        public static Tuple operator -(Tuple t1, Tuple t2)
        {
            return new Tuple(t1.X - t2.X, t1.Y - t2.Y, t1.Z - t2.Z, t1.W - t2.W);
        }

        public static Tuple operator *(Tuple t1, float scalar)
        {
            return new Tuple(t1.X * scalar, t1.Y * scalar, t1.Z * scalar, t1.W * scalar);
        }

        public static Tuple operator /(Tuple t1, float scalar)
        {
            return new Tuple(t1.X / scalar, t1.Y / scalar, t1.Z / scalar, t1.W / scalar);
        }

        public override bool Equals(object obj)
        {
            return obj is Tuple tuple && Equals(tuple);
        }

        private bool Equals(Tuple other)
        {
            return X.AlmostEqual(other.X) && Y.AlmostEqual(other.Y) && Z.AlmostEqual(other.Z) && W.AlmostEqual(other.W);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                // ReSharper disable once NonReadonlyMemberInGetHashCode
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"X:{X}, Y:{Y}, Z{Z}, W{W}";
        }
    }
}