using System;

namespace rayTracer
{
    public class Sphere
    {
        public Guid Id { get; } = new Guid();

        private Tuple CentrePoint { get; } = Tuple.Point(0, 0, 0);
        public Matrix Transform { get; set; } = Matrix.Identity;
        public Material Material { get; set; } = new Material();

        public Tuple NormalAt(Tuple worldPoint)
        {
            var inverseTransform = Transform.Inverse();

            var objectPoint = inverseTransform * worldPoint;
            var objectNormal = objectPoint - CentrePoint;
            var worldNormal = inverseTransform.Transpose() * objectNormal;
            worldNormal.W = 0;
            return worldNormal.Normalise();
        }
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