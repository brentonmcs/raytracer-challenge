namespace rayTracer
{
    public class Ray
    {
        public readonly Tuple Direction;
        public readonly Tuple Origin;

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