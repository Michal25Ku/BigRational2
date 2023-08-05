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

            return new BigRational(this.Numerator + this.Denominator, Denominator);
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

            return new BigRational(this.Numerator - this.Denominator, Denominator);
        }

        public static BigRational operator --(BigRational b)
            => b.Decrement();
        #endregion
    }
}
