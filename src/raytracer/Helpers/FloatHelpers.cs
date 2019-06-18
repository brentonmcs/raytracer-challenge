using System;

namespace rayTracer.Helpers
{
    public static class FloatHelpers
    {
        public static bool AlmostEqual(this float f1, float f2)
        {
            const float epsilon = 0.0001f;
            return Math.Abs(f1 - f2) < epsilon;
        }
    }
}