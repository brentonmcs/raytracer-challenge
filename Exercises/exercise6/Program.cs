using System;
using System.IO;
using rayTracer;
using Tuple = rayTracer.Tuple;

namespace exercise6
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

            var shape = new Sphere {Material = new Material {Color = new Color(1, 0.2f, 1)}};


            var lightPosition = Tuple.Point(-10, 10, -10);
            var lightColor = new Color(1, 1, 1);
            var light = new Light(lightPosition, lightColor);

            for (var y = 0; y < canvasPixels; y++)
            {
                var worldY = half - pixelSize * y;

                for (var x = 0; x < canvasPixels; x++)
                {
                    var worldX = -half + pixelSize * x;

                    var position = Tuple.Point(worldX, worldY, wallZ);
                    var r = new Ray(rayOrigin, (position - rayOrigin).Normalise());

                    var hit = shape.Intersections(r).Hit();
                    if (hit == null) continue;

                    var point = r.Position(hit.T);
                    var normal = hit.Object.NormalAt(point);
                    var color = hit.Object.Material.Lighting(light, point, r.Direction.Normalise(), normal);

                    Console.WriteLine("Hit");
                    canvas.WriteColor(x, y, color);
                }
            }

            File.WriteAllText("exercise6.ppm", canvas.CreatePPMLines());
        }
    }
}