using System;
using System.Collections.Generic;
using System.Linq;

namespace rayTracer
{
    public static class IntersectionHelpers
    {
        public static List<Intersection> Intersections(this Sphere sphere, Ray r)
        {
            var ray2 = r.Transform(sphere.Transform.Inverse());
            var sphereToRay = ray2.Origin - Tuple.Point(0, 0, 0);
            var a = VectorOperations.Dot(ray2.Direction, ray2.Direction);
            var b = 2 * VectorOperations.Dot(ray2.Direction, sphereToRay);
            var c = VectorOperations.Dot(sphereToRay, sphereToRay) - 1;
            var discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant < 0)
                return new List<Intersection>();

            var t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            var t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

            return new List<Intersection> {new Intersection((float) t1, sphere), new Intersection((float) t2, sphere)};
        }

        public static List<Intersection> Intersections(params Intersection[] i1)
        {
            return i1.ToList();
        }

        public static Intersection Hit(this IEnumerable<Intersection> intersections)
        {
            Intersection result = null;

            foreach (var intersection in intersections)
            {
                if (intersection.T < 0)
                    continue;

                if (result == null || intersection.T < result.T) result = intersection;
            }

            return result;
        }
    }
}