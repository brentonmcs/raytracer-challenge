using System;
using rayTracer;

namespace exercise3
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Question 1");

            var mIdentity = Matrix.Identity.Inverse();

            Console.Write(mIdentity);

            Console.WriteLine("");
            Console.WriteLine("Question 2");

            var mA = new Matrix(4, 4, new[]
            {
                3f, -9, 7, 3,
                -3, -8, 2, -9,
                -4, 4, 4, 1,
                -6, 5, 1, 1
            });

            var mAInverse = mA.Inverse();
            var mMultipliedByInverse = mA * mAInverse;

            Console.Write(mMultipliedByInverse);
            Console.WriteLine("");
            Console.WriteLine("Question 3");

            var mTransposeInverse = mA.Transpose().Inverse();
            var mInverseTranspose = mA.Inverse().Transpose();
            Console.WriteLine("");
            Console.WriteLine("Inverse of Transpose");
            Console.Write(mTransposeInverse);
            Console.WriteLine("");
            Console.WriteLine("Transpose of Inverse");
            Console.Write(mInverseTranspose);

            Console.WriteLine("");
        }
    }
}