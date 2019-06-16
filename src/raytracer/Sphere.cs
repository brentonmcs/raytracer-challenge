using System;

namespace rayTracer
{
    public class Sphere
    {
        public Guid Id { get; } = new Guid();

        public float Radias { get; set; } = 1;

        public Tuple CentrePoint { get; set; } = Tuple.Point(0, 0, 0);
        public Matrix Transform { get; set; } = Matrix.Identity;
    }


    public class Intersection
    {
        public Intersection(float time, Sphere s)
        {
            Object = s;
            T = time;
        }

        public Sphere Object { get; }
        public float T { get; }
    }
}