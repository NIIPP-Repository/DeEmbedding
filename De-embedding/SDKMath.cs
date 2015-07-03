using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKMath
{
    public class Complex
    {
        private double _re, _im;
        public double Re
        {
            get { return _re; }
        }
        public double Im
        {
            get { return _im; }
        }

        public double Abs
        {
            get { return Math.Sqrt(_re * _re + _im * _im); }
        }
        public double AngleRad
        {
            get { return Math.Atan(_im / _re); }
        }
        public double AngleDeg
        {
            get { return 180 * Math.Atan(_im / _re) / Math.PI; }
        }

        public Complex(double re, double im)
        {
            _re = re;
            _im = im;
        }

        public Complex(double abs, double angle, bool isFromExpForm)
        {
            if (isFromExpForm)
            {
                _re = abs * Math.Cos(angle * Math.PI / 180);
                _im = abs * Math.Sin(angle * Math.PI / 180);
            }
            else
            {
                _re = abs;
                _im = angle;
            }
        }

        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex(x._re + y._re, x._im + y._im);
        }
        public static Complex operator +(int x, Complex y)
        {
            return new Complex(x + y._re, y._im);
        }
        public static Complex operator +(Complex x, int y)
        {
            return new Complex(y + x._re, x._im);
        }

        public static Complex operator -(Complex x)
        {
            return new Complex(-x._re, -x._im);
        }
        public static Complex operator -(Complex x, Complex y)
        {
            return new Complex(x._re - y._re, x._im - y._im);
        }
        public static Complex operator -(int x, Complex y)
        {
            return new Complex(x - y._re, -y._im);
        }
        public static Complex operator -(Complex x, int y)
        {
            return new Complex(x._re - y, x._im);
        }

        public static Complex operator *(Complex x, Complex y)
        {
            return new Complex(y._re * x._re - y._im * x._im, y._re * x._im + y._im * x._re);
        }
        public static Complex operator *(double x, Complex y)
        {
            return new Complex(x * y._re, x * y._im);
        }
        public static Complex operator *(Complex x, double y)
        {
            return new Complex(y * x._re, y * x._im);
        }

        public static Complex operator /(Complex x, Complex y)
        {
            double div = y._re * y._re + y._im * y._im;
            return new Complex((x._re * y._re + x._im * y._im) / div, (x._im * y._re - x._re * y._im) / div);
        }
        public Complex Reverse
        {
            get
            {
                double div = _re * _re + _im * _im;
                return new Complex(_re / div, -_im / div);
            }
        }

        public override string ToString()
        {
            return _re.ToString("0.##########E+000", System.Globalization.CultureInfo.InvariantCulture) + " "
                + _im.ToString("0.##########E+000", System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    public class Matrix
    {
        private Complex _a, _b, _c, _d;
        public Complex A
        {
            get { return _a; }
        }
        public Complex B
        {
            get { return _b; }
        }
        public Complex C
        {
            get { return _c; }
        }
        public Complex D
        {
            get { return _d; }
        }

        public Matrix(Complex A, Complex B, Complex C, Complex D)
        {
            _a = A;
            _b = B;
            _c = C;
            _d = D;
        }

        /// <summary>
        /// Конструктор создает матрицу из массива точек строки s2p файла
        /// </summary>
        /// <param name="inpMas">массив содержащий массив точек, используются точки с индексами 1..8</param>
        public Matrix(double[] inpMas)
        {
            _a = new Complex(inpMas[1], inpMas[2]);
            _c = new Complex(inpMas[3], inpMas[4]);
            _b = new Complex(inpMas[5], inpMas[6]);
            _d = new Complex(inpMas[7], inpMas[8]);
        }

        public override string ToString()
        {
            return _a.ToString() + " " +
                   _c.ToString() + " " +
                   _b.ToString() + " " +
                   _d.ToString();
        }

        public static Matrix operator *(Matrix M1, Matrix M2)
        {
            return new Matrix(M1._a * M2._a + M1._b * M2._c, M1._a * M2._b + M1._b * M2._d, M1._c * M2._a + M1._d * M2._c, M1._c * M2._b + M1._d * M2._d);
        }

        public static Matrix operator -(Matrix M1, Matrix M2)
        {
            return new Matrix(M1.A - M2.A, M1.B - M2.B, M1.C - M2.C, M1.D - M2.D);
        }

        public static Matrix operator *(Complex k, Matrix M)
        {
            return new Matrix(k * M._a, k * M._b, k * M._c, k * M._d);
        }

        public static Matrix operator /(Matrix M, Complex k)
        {
            return new Matrix(M._a / k, M._b / k, M._c / k, M._d / k);
        }

        public Complex Determinant
        {
            get
            {
                return _a * _d - _b * _c;
            }
        }

        public Matrix Reverse
        {
            get
            {
                return (new Matrix(_d, -_b, -_c, _a)) / this.Determinant;
            }
        }

        // **************************
        // Свойства для деэмбеддинга

        public Matrix FromSToA
        {
            get
            {
                Complex
                    den = 2 * _c,
                    koeff1 = _b * _c;
                Complex
                    a = (koeff1 - (1 + _a) * (_d - 1)) / den,
                    b = ((1 + _a) * (1 + _d) - koeff1) / den,
                    c = ((1 - _d) * (1 - _a) - koeff1) / den,
                    d = (koeff1 + (1 - _a) * (1 + _d)) / den;
                return new Matrix(a, b, c, d);
            }
        }

        public Matrix FromAtoS
        {
            get
            {
                Complex
                    den = _a * _d - _b * _c - (_a + _c) * (_d + _c),
                    koeff1 = _a * _d - _b * _c;
                Complex
                    s11 = (koeff1 - (_a - _c) * (_d + _c)) / den,
                    s21 = -2 * _c / den,
                    s12 = -2 * koeff1 * _c / den,
                    s22 = (koeff1 - (_d - _c) * (_a + _c)) / den;
                return new Matrix(s11, s12, s21, s22);
            }
        }

        public Matrix FromSToY
        {
            get
            {
                Complex koeff1 = (1 - _a) * (1 + _d),
                        koeff2 = (1 + _a) * (1 + _d),
                        koeff3 = _c * _b,
                        den = koeff2 - koeff3;
                Complex y11 = (koeff1 + koeff3) / den,
                        y12 = (-2 * _b) / den,
                        y21 = (-2 * _c) / den,
                        y22 = ((1 + _a) * (1 - _d) + koeff3) / den;

                return new Matrix(y11, y12, y21, y22);
            }
        }

        public Matrix FromYToS
        {
            get
            {
                Complex koeff1 = _b * _c,
                        den = (1 + _a) * (1 + _d) - koeff1;

                Complex s11 = ((1 - _a) * (1 + _d) + koeff1) / den,
                        s12 = (-2 * _b) / den,
                        s21 = (-2 * _c) / den,
                        s22 = ((1 + _a) * (1 - _d) + koeff1) / den;

                return new Matrix(s11, s12, s21, s22);
            }
        }

        public Matrix FromPPToPR
        {
            get
            {
                Complex
                    koeff1 = 2 * (_d * _a - _b * _c),
                    koeff2 = _d - _d * _a + _b * _c;
                Complex
                    pr11 = (koeff2 / koeff1) + 1,
                    pr12 = _b / koeff1,
                    pr21 = koeff2 / _b,
                    pr22 = new Complex(1, 0);
                return new Matrix(pr11, pr12, pr21, pr22);
            }
        }

        public Matrix FromPPToPL
        {
            get
            {
                Complex
                    koeff1 = 2 * (_d * _a - _b * _c),
                    koeff2 = _d - _d * _a + _b * _c;
                Complex
                    pl11 = new Complex(1, 0),
                    pl12 = _b / koeff1,
                    pl21 = koeff2 / _b,
                    pl22 = (koeff2 / koeff1) + 1;
                return new Matrix(pl11, pl12, pl21, pl22);
            }
        }
    }
}