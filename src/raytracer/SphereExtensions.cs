using System;
using System.Collections.Generic;

namespace rayTracer
{
    public static class SphereExtensions
    {
        public static List<float> Intersections(this Sphere sphere, Ray ray)
        {
            var sphereToRay = ray.Origin - Tuple.Point(0, 0, 0);
            var a = VectorOperations.Dot(ray.Direction, ray.Direction);
            var b = 2 * VectorOperations.Dot(ray.Direction, sphereToRay);
            var c = VectorOperations.Dot(sphereToRay, sphereToRay) - 1;
            var discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant < 0)
                return new List<float>();

            var t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            var t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

            return new List<float> {(float) t1, (float) t2};
        }
    }
}