using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public readonly partial struct BigRational : IEquatable<BigRational>
    {
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return false;

            if(obj is BigRational)
                return base.Equals((BigRational)obj);

            return false;
        }

        public bool Equals(BigRational other) =>
               !BigRational.IsNaN(other)
            && this.Numerator == other.Numerator
            && this.Denominator == other.Denominator;

        public static bool operator ==(BigRational left, BigRational right)
            => left.Equals(right);

        public static bool operator !=(BigRational left, BigRational right)
            => !(left == right);

        public override int GetHashCode() => (Numerator, Denominator).GetHashCode();

        public static bool Equals(BigRational u1, BigRational u2)
            => u1.Equals(u2);
    }
}
