using System;
using System.Linq;
using rayTracer.Helpers;

namespace rayTracer
{
    public class Matrix
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly float[] _values;

        public static Matrix Identity = new Matrix(4, 4, new[] {1f, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1});

        public Matrix(int rows, int columns, float[] values)
        {
            _rows = rows;
            _columns = columns;
            _values = values;

            var requiredValues = _columns * rows;
            if (_values.Length != requiredValues)
                throw new NotSupportedException("There needs to be " + requiredValues + " values in the array");
        }

        private Matrix(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;

            var requiredValues = rows * columns;
            _values = new float[requiredValues];

            for (var i = 0; i < requiredValues; i++)
            {
                _values[i] = 0f;
            }
        }

        public static Matrix operator *(Matrix mA, Matrix mB)
        {
            var mR = new Matrix(mA._rows, mA._rows);
            for (var r = 0; r < mA._rows; r++)
            {
                for (var c = 0; c < mA._columns; c++)
                {
                    mR[r, c] = MultiplyRowCol(mA, mB, r, c);
                }
            }

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

        public float Determinant
        {
            get { return _values[0] * _values[3] - _values[1] * _values[2]; }
        }

        public Matrix SubMatrix(int row, int col)
        {
            var newSize = (_rows - 1) * (_columns - 1);
            var newValues = new float[newSize];
            var newIndex = 0;
            for (var i = 0; i < _values.Length; i++)
            {
                if (GetRow(i) == row || GetCol(i) == col) continue;

                newValues[newIndex] = _values[i];
                newIndex++;
            }

            return new Matrix(_rows - 1, _columns - 1, newValues);
        }


        private int GetCol(int i)
        {
            return i - GetRow(i) * _columns;
        }

        private int GetRow(int index) => index / _rows;

        private static float MultiplyRowCol(Matrix mA, Matrix mB, int r, int c)
        {
            return mA[r, 0] * mB[0, c] +
                   mA[r, 1] * mB[1, c] +
                   mA[r, 2] * mB[2, c] +
                   mA[r, 3] * mB[3, c];
        }

        public float this[int row, int col]
        {
            get => _values[GetIndex(row, col)];
            private set => _values[GetIndex(row, col)] = value;
        }

        public Matrix Transpose()
        {
            var result = new float[_rows * _columns];
            var resultIndex = 0;

            for (var c = 0; c < _columns; c++)
            for (var r = 0; r < _rows; r++)
            {
                result[resultIndex] = _values[r * _rows + c];
                resultIndex++;
            }

            return new Matrix(_rows, _columns, result);
        }

        private int GetIndex(int row, int col) => row * _columns + col;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Matrix) obj);
        }

        private bool Equals(Matrix other)
        {
            if (_values.Length != other._values.Length)
                return false;

            for (var i = 0; i < _values.Length; i++)
            {
                if (!_values[i].AlmostEqual(other._values[i]))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return _values != null ? _values.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return _values.Aggregate(string.Empty, (current, v) => current + (v + " "));
        }
    }
}