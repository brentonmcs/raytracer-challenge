namespace rayTracer
{
    public class Ray
    {
        public readonly Tuple Origin;
        public readonly Tuple Direction;

        public Ray(Tuple origin, Tuple direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Tuple Position(float time)
        {
            return Origin + Direction * time;
        }
    }
}