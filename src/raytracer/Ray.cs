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

    public static class RayExtensions
    {
        public static Ray Transform(this Ray r, Matrix m)
        {
            return new Ray(m * r.Origin, m * r.Direction);
        }
    }
}