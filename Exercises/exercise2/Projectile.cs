using rayTracer;

namespace exercise2
{
    public class Projectile
    {
        public readonly Tuple Position;
        public readonly Tuple Velocity;

        public Projectile(Tuple position, Tuple velocity)
        {
            Position = position;
            Velocity = velocity;
        }
    }
}