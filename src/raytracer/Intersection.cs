namespace rayTracer
{
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

    public class Computation
    {
        public float T { get; }
        public Sphere Object { get; }
        public Tuple Point { get; }
        public Tuple NormalV { get; }
        public Tuple EyeV { get; }
        public bool Inside { get; }

        public Computation(Intersection i, Ray ray)
        {
            T = i.T;
            Object = i.Object;


            Point = ray.Position(T);

            NormalV = Object.NormalAt(Point);
            EyeV = ray.Direction * -1;

            if (!(NormalV.Dot(EyeV) < 0)) return;

            Inside = true;
            NormalV *= -1;
        }
    }
}