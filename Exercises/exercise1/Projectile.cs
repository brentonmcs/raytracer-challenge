using rayTracer;

namespace rayRacer.runner
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

    public class Environment
    {
        public readonly Tuple Gravity;
        public readonly Tuple Wind;

        public Environment(Tuple gravity, Tuple wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        
    }
}