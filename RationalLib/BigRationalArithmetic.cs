using System;
using System.Collections.Generic;
using System.Linq;
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

            if (IsPositiveInfinity(this) && IsPositiveInfinity(other))
                return zero;

            return new BigRational((this.Numerator * other.Denominator) + (other.Numerator * this.Denominator), (this.Denominator * other.Denominator));
        }
    }
}
