using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace RationalLib
{
    public readonly struct BigRational
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        public readonly static BigRational zero = new(0);
        public readonly static BigRational one = new(1);
        public readonly static BigRational half = new(1, 2);
        public readonly static BigRational NaN = new(0, 0);

        public readonly static BigRational positiveInfinity = new(1, 0);
        public readonly static BigRational negativeInfinity = new(-1, 0);

        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;

            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
        }

        public BigRational(BigInteger value) : this(value, 1) { }
        public BigRational() : this(0, 1) { }

        public static bool IsNaN(BigRational b) => b.Numerator == 0 && b.Denominator == 0;

        public static bool IsInfinity(BigRational b) => b.Numerator != 0 && b.Denominator == 0;

        public static bool IsPositiveInfinity(BigRational b) => b.Numerator > 0 && b.Denominator == 0;

        public static bool IsNegativeInfinity(BigRational b) => b.Numerator < 0 && b.Denominator == 0;

        public static bool IsFinity(BigRational b) => b.Numerator != 0 && b.Denominator != 0;

        public override string ToString() => $"<<{Numerator}>>/<<{Denominator}>>";
    }
}