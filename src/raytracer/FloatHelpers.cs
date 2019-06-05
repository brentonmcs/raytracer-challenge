using System;

namespace rayTracer
{
    public static class FloatHelpers
    {
        public static bool AlmostEqual(this float f1, float f2)
        {
            const float epsilon = 0.000001f;
            return MathF.Abs(f1 - f2) < epsilon;
        }
    }
}