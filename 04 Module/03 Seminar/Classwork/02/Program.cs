using System;

namespace _02
{
    class Matrix2
    {
        double a11, a12, a21, a22;
        public Matrix2(double a11, double a12, double a21, double a22)
        {
            this.a11 = a11;
            this.a12 = a12;
            this.a21 = a21;
            this.a22 = a22;
        }
        public Matrix2(double a11, double a22)
        {
            this.a11 = a11;
            this.a22 = a22;
            a12 = a21 = 0;
        }
        public Matrix2(Matrix2 matrix)
        {
            a11 = matrix.a11;
            a12 = matrix.a12;
            a21 = matrix.a21;
            a22 = matrix.a22;
        }
        public double Det()
        {
            return a11 * a22 - a12 * a21;
        }
        public Matrix2 Inverse()
        {
            if (Det() == 0) throw new ArgumentException();
            return new Matrix2(a22, -a12, -a21, -a11) / Det();
        }
        public Matrix2 Transpose()
        {
            return new Matrix2(a11, a21, a12, a22);
        }
        public static Matrix2 operator +(Matrix2 m1, Matrix2 m2)
        {
            return new Matrix2(m1.a11 + m2.a11, m1.a12 + m2.a12, m1.a21 + m2.a21, m1.a22 + m2.a22);
        }
        public static Matrix2 operator -(Matrix2 m1, Matrix2 m2)
        {
            return new Matrix2(m1.a11 - m2.a11, m1.a12 - m2.a12, m1.a21 - m2.a21, m1.a22 - m2.a22);
        }
        public static Matrix2 operator *(Matrix2 m1, Matrix2 m2)
        {
            double a11 = m1.a11 * m2.a11 + m1.a12 * m2.a21;
            double a12 = m1.a11 * m2.a12 + m1.a12 * m2.a22;
            double a21 = m1.a21 * m2.a11 + m1.a22 * m2.a21;
            double a22 = m1.a21 * m2.a12 + m1.a22 * m2.a22;
            return new Matrix2(a11, a12, a21, a22);
        }
        public static Matrix2 operator /(Matrix2 m1, Matrix2 m2)
        {
            return m1 * m2.Inverse();
        }
        public static Matrix2 operator *(Matrix2 M, double k)
        {
            return new Matrix2(M.a11 * k, M.a12 * k, M.a21 * k, M.a22 * k);
        }
        public static Matrix2 operator *(double k, Matrix2 M)
        {
            return M * k;
        }
        public static Matrix2 operator /(Matrix2 M, double k)
        {
            if (k == 0) throw new ArgumentException();
            return new Matrix2(M.a11 / k, M.a12 / k, M.a21 / k, M.a22 / k);
        }
        public override string ToString()
        {
            return $"{a11}\t{a12}\n{a21}\t{a22}";
        }
    }
    class Program
    {
        static void Main()
        {
            Matrix2 m1 = new Matrix2(1, 2, 3, 4);
            Matrix2 m2 = m1.Inverse();
            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m1.Det());
            Console.WriteLine(m1.Transpose());
            Matrix2 m3 = new Matrix2(5, 6, 7, 8);
            Console.WriteLine(m1 * m3);
        }
    }
}


