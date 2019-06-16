using System;
using System.IO;
using rayTracer;
using Tuple = rayTracer.Tuple;

namespace exercise4
{
    internal class Program
    {
        private static void Main()
        {
            const int size = 80;
            const float radius = size * 3f / 8f;

            var canvas = new Canvas(size, size);
            var red = new Color(1, 0, 0);
            for (var i = 1; i <= 12; i++)
            {
                var point = ComputePoint(i);

                Console.WriteLine($"X: {(int) (point.X * radius)}, Z: {(int) (point.Z * radius)}");
                canvas.WriteColor((int) (point.X * radius) + size / 2, (int) (point.Z * radius) + size / 2, red);
            }

            File.WriteAllText("exercise4.ppm", canvas.CreatePPMLines());
        }

        public static Tuple ComputePoint(int hour)
        {
            var r = Matrix.Identity.Rotate_Y(hour * MathF.PI / 6f);

            return r * Tuple.Point(0, 0, 1);
        }
    }
}