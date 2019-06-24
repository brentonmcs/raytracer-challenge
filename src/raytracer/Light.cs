namespace rayTracer
{
    public class Light
    {
        private bool Equals(Light other)
        {
            return Equals(Position, other.Position) && Equals(Intensity, other.Intensity);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Light) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Position != null ? Position.GetHashCode() : 0) * 397) ^ (Intensity != null ? Intensity.GetHashCode() : 0);
            }
        }

        public Tuple Position { get; }
        public Color Intensity { get; }

        public Light(Tuple position, Color intensity)
        {
            Position = position;
            Intensity = intensity;
        }

        
    }
}