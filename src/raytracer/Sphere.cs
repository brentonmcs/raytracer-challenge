using System;

namespace rayTracer
{
    public class Sphere
    {
        public Guid Id { get; } = new Guid();

        public float Radias { get; set; } = 1;

        public Tuple CentrePoint { get; set; } = Tuple.Point(0,0,0);

        public Sphere()
        {
        }
    }
}