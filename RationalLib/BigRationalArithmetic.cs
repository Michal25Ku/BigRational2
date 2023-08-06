using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public readonly partial struct BigRational
    {
        #region Plus
        public BigRational Plus(BigRational other)
        {
            if (IsNaN(this) || IsNaN(other))
                return NaN;

            if ((IsPositiveInfinity(this) && IsNegativeInfinity(other)) || (IsNegativeInfinity(this) && IsPositiveInfinity(other)))
                return zero;

            if (IsPositiveInfinity(this) || IsPositiveInfinity(other))
                return positiveInfinity;

            if (IsNegativeInfinity(this) || IsNegativeInfinity(other))
                return negativeInfinity;

            return new BigRational((this.Numerator * other.Denominator) + (other.Numerator * this.Denominator), (this.Denominator * other.Denominator));
        }

        public static BigRational Sum(BigRational first, params BigRational[] b)
        {
            BigRational sum = first;

            for(int i = 0; i < b.Length; i++)
            {
                sum = sum.Plus(b[i]);
            }

            return sum;
        }

        public static BigRational operator +(BigRational left, BigRational right) 
            => left.Plus(right);

        #endregion

        #region Minus
        public BigRational Substract(BigRational other)
        {
            if (IsNaN(this) || IsNaN(other))
                return NaN;

            if (IsPositiveInfinity(this) && IsNegativeInfinity(other))
                return positiveInfinity;

            if (IsNegativeInfinity(this) && IsPositiveInfinity(other))
                return negativeInfinity;

            if ((IsPositiveInfinity(this) && IsPositiveInfinity(other)) || (IsNegativeInfinity(this) && IsNegativeInfinity(other)))
                return zero;

            if (IsPositiveInfinity(this) || IsNegativeInfinity(other))
                return positiveInfinity;

            if (IsNegativeInfinity(this) && IsPositiveInfinity(other))
                return negativeInfinity;

            return new BigRational((this.Numerator * other.Denominator) - (other.Numerator * this.Denominator), (this.Denominator * other.Denominator));
        }

        public static BigRational Devide(BigRational first, params BigRational[] b)
        {
            BigRational dev = first;

            for (int i = 0; i < b.Length; i++)
            {
                dev = dev.Substract(b[i]);
            }

            return dev;
        }

        public static BigRational operator -(BigRational left, BigRational right)
            => left.Substract(right);
        #endregion

        #region Multiply
        public BigRational Multiply(BigRational other)
        {
            if (IsNaN(this) || IsNaN(other))
                return NaN;

            if (this == zero || other == zero)
                return zero;

            if (IsPositiveInfinity(this) && IsNegativeInfinity(other) || (IsNegativeInfinity(this) && IsPositiveInfinity(other)))
                return negativeInfinity;

            if ((IsPositiveInfinity(this) && IsPositiveInfinity(other)) || (IsNegativeInfinity(this) && IsNegativeInfinity(other)))
                return positiveInfinity;

            if (IsPositiveInfinity(this) || IsPositiveInfinity(other))
                return positiveInfinity;

            if (IsNegativeInfinity(this) || IsNegativeInfinity(other))
                return negativeInfinity;

            return new BigRational(this.Numerator * other.Numerator, this.Denominator * other.Denominator);
        }

        public static BigRational Multiply(BigRational first, params BigRational[] b)
        {
            BigRational mult = first;

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == zero)
                    return zero;

                mult = mult.Multiply(b[i]);
            }

            return mult;
        }

        public static BigRational operator *(BigRational left, BigRational right)
            => left.Multiply(right);
        #endregion

        #region Division
        public BigRational Division(BigRational other)
        {

            if (IsNaN(this) || IsNaN(other) || this.Denominator == 0 || other.Denominator == 0 || other == zero || IsInfinity(this) || IsInfinity(other))
                return NaN;

            if (this == zero)
                return zero;

            return new BigRational(this.Numerator * other.Denominator, this.Denominator * other.Numerator);
        }

        public static BigRational Division(BigRational first, params BigRational[] b)
        {
            BigRational div = first;

            if (IsNaN(first) || first.Denominator == 0 || IsInfinity(first))
                return NaN;

            if (first == zero)
                return zero;

            for (int i = 0; i < b.Length; i++)
            {
                if (IsNaN(b[i]) || b[i].Denominator == 0 || b[i] == zero)
                    return NaN;

                if (IsInfinity(b[i]))
                    return zero;

                div = div.Division(b[i]);
            }

            return div;
        }

        public static BigRational operator /(BigRational left, BigRational right)
            => left.Division(right);
        #endregion

        #region Inversion
        public BigRational Inverse()
        {
            if (IsNaN(this))
                return NaN;

            return new BigRational((-1) * this.Numerator, this.Denominator);
        }

        public static BigRational operator -(BigRational b)
            => b.Inverse();
        #endregion

        #region Increment
        public BigRational Increment()
        {
            if (IsNaN(this))
                return NaN;

            if (IsPositiveInfinity(this))
                return positiveInfinity;

            if (IsNegativeInfinity(this))
                return negativeInfinity;

            return BigRational.Sum(this, new BigRational(this.Denominator, this.Denominator));
        }

        public static BigRational operator ++(BigRational b)
            => b.Increment();
        #endregion

        #region Decrement
        public BigRational Decrement()
        {
            if (IsNaN(this))
                return NaN;

            if (IsPositiveInfinity(this))
                return positiveInfinity;

            if (IsNegativeInfinity(this))
                return negativeInfinity;

            return BigRational.Devide(this, new BigRational(this.Denominator, this.Denominator));
        }

        public static BigRational operator --(BigRational b)
            => b.Decrement();
        #endregion

        #region Abs
        public BigRational Abs()
        {
            if (IsNaN(this))
                return NaN;

            if (this < 0)
                return new BigRational((-1) * Numerator, Denominator);
            else
                return this;
        }

        public static BigRational Abs(BigRational b)
        {
            return b.Abs();
        }
        #endregion

        #region Sign
        public BigRational Sign()
        {
            if (IsNaN(this))
                return NaN;

            if (this < 0)
                return new BigRational(-1, 1);
            else if (this == 0)
                return zero;
            else
                return new BigRational(1, 1);
        }

        public static BigRational Sign(BigRational b)
        {
            return b.Sign();
        }
        #endregion

        #region Floor
        public BigRational Floor()
        {
            if (IsNaN(this) || IsInfinity(this))
                return NaN;

            if (this > 0)
                return new BigRational(this.Numerator - (this.Numerator % this.Denominator), this.Denominator);
            if (this == 0)
                return zero;
            else
                return new BigRational(this.Numerator - (this.Numerator % this.Denominator) - this.Denominator, this.Denominator);
        }

        public static BigRational Floor(BigRational b)
        {
            return b.Floor();
        }
        #endregion

        #region Ceiling
        public BigRational Ceiling()
        {
            if (IsNaN(this) || IsInfinity(this))
                return NaN;

            if (this > 0)
                return new BigRational(this.Numerator - (this.Numerator % this.Denominator) + this.Denominator, this.Denominator);
            else if (this == 0)
                return zero;
            else
                return new BigRational(this.Numerator - (this.Numerator % this.Denominator), this.Denominator);
        }

        public static BigRational Ceiling(BigRational b)
        {
            return b.Ceiling();
        }
        #endregion

        #region Max
        public static BigRational Max(BigRational b1, BigRational b2)
        {
            if (IsNaN(b1) || IsNaN(b2))
                return NaN;

            if (IsPositiveInfinity(b1) || IsPositiveInfinity(b2))
                return positiveInfinity;

            if(IsNegativeInfinity(b1) && !IsNegativeInfinity(b2))
                return b2;

            if (!IsNegativeInfinity(b1) && IsNegativeInfinity(b2))
                return b1;

            if (b1 >= b2)
                return b1;
            else
                return b2;
        }
        #endregion

        #region Pow
        public static BigRational Pow(BigRational b, double p)
        {
            if (IsNaN(b))
                return NaN;

            if (p == 0)
                return one;

            if(IsPositiveInfinity(b))
                return positiveInfinity;

            if(IsNegativeInfinity(b))
                return negativeInfinity;

            double bToDouble = (double)b;
            bToDouble = Math.Pow(bToDouble, p);

            return (BigRational)bToDouble;
        }
        #endregion
    }
}
