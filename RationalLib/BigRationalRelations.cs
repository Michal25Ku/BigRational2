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
            if(this.Equals(other))
                return 0;

            if(this.Numerator != other.Numerator || this.Denominator != other.Denominator)
                return this.CompareTo((decimal)other);
            else
                return 0;
        }

        public int CompareTo(object? obj)
        {
            if(obj is null)
                return 0;

            if(obj is BigRational)
                return CompareTo((BigRational)obj);

            return 0;
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
