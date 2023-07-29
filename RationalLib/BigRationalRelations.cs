using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public readonly partial struct BigRational : IComparable ,IComparable<BigRational>
    {
        public int CompareTo(BigRational other)
        {
            if (this.Equals(other) || (IsNaN(this) && IsNaN(other))) return 0;

            if (IsNaN(this) && !IsNaN(other)) return -1;
            if (IsNaN(other) && !IsNaN(this)) return 1;

            if (IsPositiveInfinity(this) && IsNegativeInfinity(other)) return 1;
            if (IsNegativeInfinity(this) && IsPositiveInfinity(other)) return -1;

            if (IsPositiveInfinity(this))
                return 1;
            else if (IsPositiveInfinity(other))
                return -1;

            if (IsNegativeInfinity(this))
                return -1;
            else if (IsNegativeInfinity(other))
                return 1;

            if (this.Numerator != other.Numerator || this.Denominator != other.Denominator)
                return (this.Numerator * other.Denominator).CompareTo(other.Numerator * this.Denominator);
            else
                return 0;
        }

        public int CompareTo(object? obj)
        {
            if(obj is null)
                return 1;

            if (obj is not BigRational)
                throw new ArgumentException();

            return this.CompareTo((BigRational)obj);
        }

        public static bool operator >(BigRational left, BigRational right)
            => left.CompareTo(right) > 0;

        public static bool operator <(BigRational left, BigRational right)
            => left.CompareTo(right) < 0;

        public static bool operator >=(BigRational left, BigRational right)
            => left.CompareTo(right) >= 0;

        public static bool operator <=(BigRational left, BigRational right)
            => left.CompareTo(right) <= 0;
    }
}
