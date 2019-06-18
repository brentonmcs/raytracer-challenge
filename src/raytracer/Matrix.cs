using System;
using System.Text;
using rayTracer.Helpers;

namespace rayTracer
{
    public class Matrix
    {
        public readonly int Columns;
        public readonly int Rows;
        public float[] Values;

        public Matrix(int rows, int columns, float[] values)
        {
            Rows = rows;
            Columns = columns;
            Values = values;


            var requiredValues = Columns * rows;
            if (Values.Length != requiredValues)
                throw new NotSupportedException("There needs to be " + requiredValues + " values in the array");
        }


        private Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            var requiredValues = rows * columns;
            Values = new float[requiredValues];

            for (var i = 0; i < requiredValues; i++) Values[i] = 0f;
        }

        public static Matrix Identity => new Matrix(4, 4, new[] {1f, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1});

        public float Determinant
        {
            get
            {
                if (Columns == 2) return Values[0] * Values[3] - Values[1] * Values[2];

                var result = 0f;
                for (var i = 0; i < Columns; i++) result += Values[i] * Cofactor(0, i);

                return result;
            }
        }

        public bool Invertible => !Determinant.AlmostEqual(0);

        public float this[int row, int col]
        {
            get => Values[GetIndex(row, col)];
            set => Values[GetIndex(row, col)] = value;
        }

        public static Matrix operator *(Matrix mA, Matrix mB)
        {
            var mR = new Matrix(mA.Rows, mA.Rows);
            for (var r = 0; r < mA.Rows; r++)
            for (var c = 0; c < mA.Columns; c++)
                mR[r, c] = MultiplyRowCol(mA, mB, r, c);

            return mR;
        }

        public static Tuple operator *(Matrix mA, Tuple t)
        {
            var mT = new Matrix(4, 1, new[] {t.X, t.Y, t.Z, t.W});

            var x = MultiplyRowCol(mA, mT, 0, 0);
            var y = MultiplyRowCol(mA, mT, 1, 0);
            var z = MultiplyRowCol(mA, mT, 2, 0);
            var w = MultiplyRowCol(mA, mT, 3, 0);

            return new Tuple(x, y, z, w);
        }

        public float Minor(int row, int col)
        {
            return SubMatrix(row, col).Determinant;
        }

        public Matrix SubMatrix(int row, int col)
        {
            var newSize = (Rows - 1) * (Columns - 1);
            var newValues = new float[newSize];
            var newIndex = 0;
            for (var i = 0; i < Values.Length; i++)
            {
                if (GetRow(i) == row || GetCol(i) == col) continue;

                newValues[newIndex] = Values[i];
                newIndex++;
            }

            return new Matrix(Rows - 1, Columns - 1, newValues);
        }

        public float Cofactor(int row, int col)
        {
            var minor = Minor(row, col);

            return (row + col) % 2 == 0 ? minor : minor * -1;
        }

        private int GetCol(int i)
        {
            return i - GetRow(i) * Columns;
        }

        private int GetRow(int index)
        {
            return index / Rows;
        }

        private static float MultiplyRowCol(Matrix mA, Matrix mB, int r, int c)
        {
            return mA[r, 0] * mB[0, c] +
                   mA[r, 1] * mB[1, c] +
                   mA[r, 2] * mB[2, c] +
                   mA[r, 3] * mB[3, c];
        }


        internal int GetIndex(int row, int col)
        {
            return row * Columns + col;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Matrix) obj);
        }

        private bool Equals(Matrix other)
        {
            if (Values.Length != other.Values.Length)
                return false;

            for (var i = 0; i < Values.Length; i++)
                if (!Values[i].AlmostEqual(other.Values[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return Values?.GetHashCode() ?? 0;
        }


        public override string ToString()
        {
            var resultStr = new StringBuilder();

            for (var r = 0; r < Rows; r++)
            {
                for (var c = 0; c < Columns; c++)
                {
                    resultStr.Append(" | " + this[r, c]);

                    if (c == Columns - 1) resultStr.Append(" |");
                }

                resultStr.AppendLine();
            }

            return resultStr.ToString();
        }

        public static Matrix Scaling(float x, float y, float z) => Identity.Scaling(x, y, z);
        public static Matrix Translation(float x, float y, float z) => Identity.Translation(x, y, z);
        public static Matrix Shearing(float xy, float xz, float yx, float yz, float zx, float zy) => Identity.Shearing(xy,xz,yx,yz,zx,zy);

        public static Matrix Rotate_Z(float r) => Identity.Rotate_Z(r);
    }
}