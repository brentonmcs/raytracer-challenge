using System;
using System.IO;
using rayTracer;
using Tuple = rayTracer.Tuple;

namespace exercise5
{
    class Program
    {
        static void Main()
        {
            var rayOrigin = Tuple.Point(0, 0, -5);

            const float wallZ = 10f;
            const float wallSize = 7f;
            const int canvasPixels = 100;
            const float pixelSize = wallSize / canvasPixels;
            const float half = wallSize / 2;

            var canvas = new Canvas(canvasPixels, canvasPixels);

            var color = new Color(1, 0, 0);
            var shape = new Sphere {Transform = Matrix.Scaling(1, 0.5f, 1)};

            for (var y = 0; y < canvasPixels; y++)
            {
                var worldY = half - pixelSize * y;

                for (var x = 0; x < canvasPixels; x++)
                {
                    var worldX = -half + pixelSize * x;
                    
                    var position = Tuple.Point(worldX, worldY, wallZ);
                    var r = new Ray(rayOrigin, (position - rayOrigin).Normalise());

                    var xs = shape.Intersections(r);

                    Console.WriteLine($"World X {worldX}, WorldY {worldY}, Intersections Count {xs.Count}");
                    if (xs.Hit() == null) continue;

                    Console.WriteLine("Hit");
                    canvas.WriteColor(x, y, color);
                }
            }

            File.WriteAllText("exercise5.ppm", canvas.CreatePPMLines());
        }
    }
}