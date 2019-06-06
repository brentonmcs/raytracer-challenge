using rayTracer;

namespace rayRacer.runner
{
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