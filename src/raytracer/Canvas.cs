using System;
using System.Text;

namespace rayTracer
{
    public class Canvas
    {
        private readonly Color[,] _pixelColors;
        public readonly int Height;
        public readonly int Width;

        public Canvas(int width, int height, Color background = null)
        {
            Width = width;
            Height = height;

            _pixelColors = new Color[height, width];

            for (var h = 0; h < height; h++)
            for (var w = 0; w < width; w++)
                _pixelColors[h, w] = background ?? new Color(0, 0, 0);
        }

        public void WriteColor(int width, int height, Color c)
        {
            _pixelColors[height, width] = c;
        }

        public Color GetColor(int width, int height)
        {
            return _pixelColors[height, width];
        }


        public string CreatePPMLines()
        {
            var str = new StringBuilder();
            str.AppendLine("P3");
            str.AppendLine($"{Width} {Height}");
            str.AppendLine("255");

            for (var h = 0; h < Height; h++)
            {
                var line = new StringBuilder();

                for (var w = 0; w < Width; w++)
                    //                    foreach (var sS in _pixelColors[h, w].ScaledString.Split(" "))
//                    {
//                        if (!newLine && (sS.Length + line.Length) / 70d > 1d)
//                        {
//                            line.Remove(line.Length - 1, 1);
//                            line.Append("\n");
//                            newLine = true;
//                        }
//
//                        line.Append(sS + " ");
//                    }

                    line.Append(_pixelColors[h, w].ScaledString + " ");

                AddLineBreaks(line);


                str.Append(line.ToString().Trim() + "\n");
            }

            return str.ToString();
        }

        private static void AddLineBreaks(StringBuilder line)
        {
            var curPos = 0;
            var endPos = 70;

            while (curPos + 70 < line.Length)
            {
                while (!char.IsWhiteSpace(line[curPos + endPos])) endPos--;

                line[curPos + endPos] = Convert.ToChar("\n");
                curPos += endPos;
                endPos = 70;
            }
        }
    }
}