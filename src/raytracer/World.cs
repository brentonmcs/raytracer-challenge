using System.Collections.Generic;
using System.Linq;

namespace rayTracer
{
    public class World
    {
        public List<Sphere> Objects { get; set; } = new List<Sphere>();

        public List<Light> Light { get; set; }

        public List<Intersection> Intersect(Ray ray)
        {
            var result = new List<Intersection>();
            foreach (var sphere in Objects)
            {
                result.AddRange(sphere.Intersections(ray));
            }

            return result.OrderBy(x => x.T).ToList();
        }

        public Color ShadeHit(Computation comps)
        {
            var c = new Tuple(0,0,0,0);

            foreach (var ls in Light)
            {
                c += comps.Object.Material.Lighting(ls, comps.Point, comps.EyeV, comps.NormalV);
            }

            return new Color(c);

        }

        public Color ColorAt(Ray ray)
        {
            var hit = Intersect(ray).Hit();
            return hit == null ? new Color(0,0,0) : ShadeHit(new Computation(hit, ray));
        }
    }
}