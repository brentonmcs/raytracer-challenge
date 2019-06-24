namespace rayTracer
{
    public static class RayExtensions
    {
        public static Ray Transform(this Ray r, Matrix m)
        {
            return new Ray(m * r.Origin, m * r.Direction);
        }
    }
}