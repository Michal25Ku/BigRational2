using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public readonly partial struct BigRational
    {
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
            BigRational sum = first;

            for (int i = 0; i < b.Length; i++)
            {
                sum = sum.Substract(b[i]);
            }

            return sum;
        }

        public static BigRational operator -(BigRational left, BigRational right)
            => left.Substract(right);
    }
}
