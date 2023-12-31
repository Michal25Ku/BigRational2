﻿global using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace RationalLib
{
    public readonly partial struct BigRational
    {
        public BigInteger Numerator { get; init; } = 0;
        public BigInteger Denominator { get; init; } = 1;

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

            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }

            if (Numerator == 0 && Denominator == 0)
                return;

            if (Numerator == 0 && Denominator == 1)
            {
                (Numerator, Denominator) = (0, 1);
                return;
            }

            if (Numerator == 0 && Denominator != 0)
            {
                Denominator = 1;
                return;
            }

            if (Numerator == 1 && Denominator == 1)
            {
                (Numerator, Denominator) = (1, 1);
                return;
            }

            if (Numerator == Denominator)
            {
                (Numerator, Denominator) = (1, 1);
                return;
            }

            if (Numerator == 1 && Denominator == 2)
            {
                (Numerator, Denominator) = (1, 2);
                return;
            }

            if (2 * Numerator == Denominator)
            {
                (Numerator, Denominator) = (1, 2);
                return;
            }

            if (Numerator < 0 && Denominator == 0)
            {
                (Numerator, Denominator) = (-1, 0);
                return;
            }

            if (Numerator > 0 && Denominator == 0)
            {
                (Numerator, Denominator) = (1, 0);
                return;
            }

            if (Numerator == 1)
                return;

            if (Denominator == 1)
                return;


            var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public BigRational(BigInteger value) : this(value, 1) { }
        public BigRational() : this(0, 1) { }

        public BigRational(string stringValue)
        {
            if (!IsCorrectBigRationalString(stringValue))
                throw new ArgumentException("Incorrectly specified BigRational type in the form of a string");

            this = new BigRational(Int32.Parse(stringValue.Split('/')[0]), Int32.Parse(stringValue.Split('/')[1]));
        }

        public static bool IsNaN(BigRational b) => b.Numerator == 0 && b.Denominator == 0;

        public static bool IsInfinity(BigRational b) => b.Numerator != 0 && b.Denominator == 0;

        public static bool IsPositiveInfinity(BigRational b) => b.Numerator > 0 && b.Denominator == 0;

        public static bool IsNegativeInfinity(BigRational b) => b.Numerator < 0 && b.Denominator == 0;

        public static bool IsFinity(BigRational b) => b.Numerator != 0 && b.Denominator != 0;

        public override string ToString()
        {
            if (IsNaN(this) == true)
                return "NaN";
            if (IsPositiveInfinity(this) == true)
                return "POSITIVE_INFINITY";
            if (IsNegativeInfinity(this) == true)
                return "NEGATIVE_INFINITY";

            return $"{Numerator}/{Denominator}";
        }

        static bool IsCorrectBigRationalString(string rationalString)
        {
            string[] stringComponents = rationalString.Trim().Split('/');

            if (stringComponents.Length > 2)
            {
                return false;
            }

            if (!stringComponents[0].Any(char.IsNumber))
            {
                return false;
            }

            if (!stringComponents[1].Any(char.IsNumber))
            {
                return false;
            }

            return true;
        }
    }
}