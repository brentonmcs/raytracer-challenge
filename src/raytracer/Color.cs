using System;

namespace rayTracer
{
    public class Color : Tuple
    {
        public Color(float red, float green, float blue) : base(red, green, blue, 0)
        {
        }

        public Color(Tuple specular) : base(specular.X, specular.Y, specular.Z, 0)
        {
            
        }

        public float Red => X;
        public float Green => Y;

        public float Blue => Z;

        public string ScaledString => $"{ScaleColor(Red)} {ScaleColor(Green)} {ScaleColor(Blue)}";

        private static int ScaleColor(float color)
        {
            var clampColor = ClampColor(color) * 256f;
            var scaledColor = (int) Math.Floor(clampColor);
            return scaledColor == 256 ? 255 : scaledColor;
        }

        private static float ClampColor(float color)
        {
            if (color < 0f)
                return 0;
            if (color > 1f)
                return 1;
            return color;
        }

        public static Color operator *(Color t1, Color t2)
        {
            return new Color(t1.Red * t2.Red, t1.Green * t2.Green, t1.Blue * t2.Blue);
        }
    }
}