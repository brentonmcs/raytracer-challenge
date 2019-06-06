
using rayTracer;

namespace exercise2
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