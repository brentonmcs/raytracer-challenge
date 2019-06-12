using System;

namespace rayTracer
{
    public static class MatrixFluentApi
    {
        public static Matrix Rotate_X(this Matrix inMatrix, float r)
        {
            var m = Matrix.Identity;
            m[1, 1] = Convert.ToSingle(Math.Cos(r));
            m[1, 2] = Convert.ToSingle(-Math.Sin(r));
            m[2, 1] = Convert.ToSingle(Math.Sin(r));
            m[2, 2] = Convert.ToSingle(Math.Cos(r));
            return  m * inMatrix;
        }
        
        public static Matrix Rotate_Y(this Matrix inMatrix, float r)
        {
            var m = Matrix.Identity;
            m[0, 0] = Convert.ToSingle(Math.Cos(r));
            m[0, 2] = Convert.ToSingle(Math.Sin(r));
            m[2, 0] = Convert.ToSingle(-Math.Sin(r));
            m[2, 2] = Convert.ToSingle(Math.Cos(r));
            return  m * inMatrix;
        }
        
        public static Matrix Rotate_Z(this Matrix inMatrix, float r)
        {
            var m = Matrix.Identity;
            m[0, 0] = Convert.ToSingle(Math.Cos(r));
            m[0, 1] = Convert.ToSingle(-Math.Sin(r));
            m[1, 0] = Convert.ToSingle(Math.Sin(r));
            m[1, 1] = Convert.ToSingle(Math.Cos(r));
            return  m * inMatrix;
        }
        
        public static Matrix Shearing(this Matrix inMatrix,  float xy, float xz, float yx, float yz, float zx, float zy)
        {
            var m = Matrix.Identity;
            m[0, 1] = xy;
            m[0, 2] = xz;
            m[1, 0] = yx;
            m[1, 2] = yz;
            m[2, 0] = zx;
            m[2, 1] = zy;
            return  m * inMatrix;
        }

        public static Matrix Scaling(this Matrix inMatrix, float x, float y, float z)
        {
            var m = Matrix.Identity;
            m[0, 0] = x;
            m[1, 1] = y;
            m[2, 2] = z;
            return m * inMatrix;
        }

        public static Matrix Translation(this Matrix inMatrix, float x, float y, float z)
        {
            var m = Matrix.Identity;
            m[0, 3] = x;
            m[1, 3] = y;
            m[2, 3] = z;
            return  m * inMatrix;
        }
        
        public static Matrix Transpose(this Matrix m)
        {
            var result = new float[m.Rows * m.Columns];
            var resultIndex = 0;

            for (var c = 0; c < m.Columns; c++)
            for (var r = 0; r < m.Rows; r++)
            {
                result[resultIndex] = m.Values[r * m.Rows + c];
                resultIndex++;
            }

            return new Matrix(m.Rows, m.Columns, result);
        }

        
        public static Matrix Inverse(this Matrix m)
        {
            if (!m.Invertible)
                throw new NotSupportedException("Matrix is not invertible");

            var result = new float[m.Rows * m.Columns];

            var mD = m.Determinant;
            for (var r = 0; r < m.Rows; r++)
            {
                for (var c = 0; c < m.Columns; c++)
                {
                    var cf = m.Cofactor(r, c);

                    var index = m.GetIndex(c, r);
                    result[index] = cf / mD;
                }
            }

            return new Matrix(m.Rows, m.Columns, result);
        }
    }
}