using System;
using System.Collections.Generic;
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

        public bool Equals(BigRational other)
        {
            if (ReferenceEquals(this, other))
                return true;
        }

        public static bool operator ==(BigRational left, BigRational right)
            => throw new NotImplementedException();

        public static bool operator !=(BigRational left, BigRational right)
            => throw new NotImplementedException();
    }
}
