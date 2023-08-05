using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public readonly partial struct BigRational : IConvertible
    {
        public static implicit operator BigRational(byte n) => new BigRational(n,1);
        public static implicit operator BigRational(short n) => new BigRational(n,1);
        public static implicit operator BigRational(ushort n) => new BigRational(n,1);
        public static implicit operator BigRational(uint n) => new BigRational(n,1);
        public static implicit operator BigRational(long n) => new BigRational(n,1);
        public static implicit operator BigRational(ulong n) => new BigRational(n,1);

        public static implicit operator BigRational(float b)
        {
            int floatPlaces = BitConverter.GetBytes(decimal.GetBits((decimal)b)[3])[2];
            return new BigRational((BigInteger)Math.Round(b * Math.Pow(10, floatPlaces)), (BigInteger)Math.Round(Math.Pow(10, floatPlaces)));
        }

        public static implicit operator BigRational(double b)
        {
            int floatPlaces = BitConverter.GetBytes(decimal.GetBits((decimal)b)[3])[2];
            return new BigRational((BigInteger)Math.Round(b * Math.Pow(10, floatPlaces)), (BigInteger)Math.Round(Math.Pow(10, floatPlaces)));
        }

        public static implicit operator BigRational(decimal b)
        {
            int floatPlaces = BitConverter.GetBytes(decimal.GetBits(b)[3])[2];
            return new BigRational((BigInteger)Math.Round(b * (decimal)Math.Pow(10, floatPlaces)), (BigInteger)Math.Round((decimal)Math.Pow(10, floatPlaces)));
        }

        public static explicit operator byte(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? (byte)0 : (byte)(b.Numerator / b.Denominator);
        public static explicit operator short(BigRational b) => (short)(b.Numerator / b.Denominator);
        public static explicit operator ushort(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? (ushort)0 : (ushort)(b.Numerator / b.Denominator);
        public static explicit operator uint(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? 0 : (uint)(b.Numerator / b.Denominator);
        public static explicit operator long(BigRational b) => (long)(b.Numerator / b.Denominator);
        public static explicit operator ulong(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? 0 : (ulong)(b.Numerator / b.Denominator);

        public static explicit operator int(BigRational b) => (int)b.Numerator / (int)b.Denominator;
        public static explicit operator double(BigRational b) => (double)b.Numerator / (double)b.Denominator;
        public static explicit operator float(BigRational b) => (float)b.Numerator / (float)b.Denominator;
        public static explicit operator decimal(BigRational b) => (decimal)b.Numerator / (decimal)b.Denominator;

        public static BigRational Parse(string rationalString)
        {
            string[] stringComponents = rationalString.Split('/');

            if (!IsCorrectBigRationalString(rationalString))
                throw new ArgumentException("Incorrectly specified BigRational type in the form of a string");

            return new BigRational(Int32.Parse(stringComponents[0]), Int32.Parse(stringComponents[1]));
        }

        public static bool TryParse(string rationalString, out BigRational bigRational)
        {
            if (!IsCorrectBigRationalString(rationalString))
            {
                bigRational = NaN;
                return false;
            }

            string[] stringComponents = rationalString.Split('/');

            bigRational = new BigRational(Int32.Parse(stringComponents[0]), Int32.Parse(stringComponents[1]));
            return true;
        }

        public TypeCode GetTypeCode() => TypeCode.Object;

        public bool ToBoolean(IFormatProvider? provider)
        {
            if (Numerator != 0 || Denominator != 0)
                return true;
            else
                return false;
        }

        public byte ToByte(IFormatProvider? provider) => (byte)this;

        public char ToChar(IFormatProvider? provider) => Convert.ToChar(this);

        public DateTime ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(this);

        public decimal ToDecimal(IFormatProvider? provider) => (decimal)this;

        public double ToDouble(IFormatProvider? provider) => (double)this;

        public short ToInt16(IFormatProvider? provider) => (short)this;

        public int ToInt32(IFormatProvider? provider) => (int)this;

        public long ToInt64(IFormatProvider? provider) => (long)this;

        public sbyte ToSByte(IFormatProvider? provider) => (sbyte)this;

        public float ToSingle(IFormatProvider? provider) => (float)this;

        public string ToString(IFormatProvider? provider) => ToString();

        public object ToType(Type conversionType, IFormatProvider? provider)
            => Convert.ChangeType(this, conversionType);

        public ushort ToUInt16(IFormatProvider? provider) => (ushort)this;

        public uint ToUInt32(IFormatProvider? provider) => (uint)this;

        public ulong ToUInt64(IFormatProvider? provider) => (ulong)this;
    }
}
