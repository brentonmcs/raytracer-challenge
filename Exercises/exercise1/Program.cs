using System;
using Tuple = rayTracer.Tuple;

namespace exercise1
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once ArrangeTypeModifiers
    class Program
    {
        // ReSharper disable once ArrangeTypeMemberModifiers
        static void Main()
        {
            var p = new Projectile(Tuple.Point(0, 1, 0), Tuple.Vector(1, 1, 0).Normalise());
            var e = new Environment(Tuple.Vector(0, -0.1f, 0), Tuple.Vector(-0.01f, 0, 0));

            var i = 0;
            Console.WriteLine($"Count: {i} Position: {p.Position}");
            while (p.Position.Y >= 0)
            {
                p = Tick(e, p);
                i++;
                Console.WriteLine($"Count: {i} Position: {p.Position}");
            }
        }

        private static Projectile Tick(Environment e, Projectile projectile)
        {
            return new Projectile(projectile.Position + projectile.Velocity, projectile.Velocity + e.Gravity + e.Wind);
        }
    }
}