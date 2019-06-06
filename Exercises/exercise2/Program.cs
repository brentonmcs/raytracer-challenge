using System;
using System.IO;
using rayTracer;
using Tuple = rayTracer.Tuple;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = Tuple.Point(0, 1, 0);
            var velocity = Tuple.Vector(1f, 1.8f, 0f).Normalise() * 11.25f;

            var p = new Projectile(start, velocity);
            var gravity = Tuple.Vector(0, -0.1f, 0); 
            var wind = Tuple.Vector(-0.01f, 0, 0);
            var e = new Environment(gravity, wind);
            const int height = 500;

            var c = new Canvas(900, height);
            var c1 = new Color(0, 1, 0);

            var i = 0;
            while (p.Position.Y <= 500 && p.Position.Y >= 0)
            {
                Console.WriteLine(p.Position);
                c.WriteColor(Convert.ToInt32(MathF.Ceiling(p.Position.X)),
                    height - Convert.ToInt32(MathF.Ceiling(p.Position.Y)),
                    c1);
                p = Tick(e, p);
                i++;
            }
            
            File.WriteAllText("exercise.ppm", c.CreatePPMLines());
        }

        private static Projectile Tick(Environment e, Projectile projectile)
        {
            return new Projectile(projectile.Position + projectile.Velocity, projectile.Velocity + e.Gravity + e.Wind);
        }
    }
}