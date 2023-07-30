using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalLib
{
    public readonly partial struct BigRational
    {
        public static implicit operator BigRational(byte n) => new BigRational(n,1);
        public static implicit operator BigRational(sbyte n) => new BigRational(n,1);
        public static implicit operator BigRational(short n) => new BigRational(n,1);
        public static implicit operator BigRational(ushort n) => new BigRational(n,1);
        public static implicit operator BigRational(uint n) => new BigRational(n,1);
        public static implicit operator BigRational(long n) => new BigRational(n,1);
        public static implicit operator BigRational(ulong n) => new BigRational(n,1);

        public static explicit operator byte(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? (byte)0 : (byte)(b.Numerator / b.Denominator);
        public static explicit operator sbyte(BigRational b) => (sbyte)(b.Numerator / b.Denominator);
        public static explicit operator short(BigRational b) => (short)(b.Numerator / b.Denominator);
        public static explicit operator ushort(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? (ushort)0 : (ushort)(b.Numerator / b.Denominator);
        public static explicit operator uint(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? 0 : (uint)(b.Numerator / b.Denominator);
        public static explicit operator long(BigRational b) => (long)(b.Numerator / b.Denominator);
        public static explicit operator ulong(BigRational b) => ((b.Numerator / b.Denominator) < 0) ? 0 : (ulong)(b.Numerator / b.Denominator);
        public byte ToByte(IFormatProvider? provider) => (byte)this;
        public sbyte ToSbyte(IFormatProvider? provider) => (sbyte)this;
        public short ToShort(IFormatProvider? provider) => (short)this;
        public ushort ToUshort(IFormatProvider? provider) => (ushort)this;
        public uint ToUint(IFormatProvider? provider) => (uint)this;
        public long ToLong(IFormatProvider? provider) => (long)this;
        public ulong ToUlong(IFormatProvider? provider) => (ulong)this;

        public static explicit operator int(BigRational b) => (int)(b.Numerator / b.Denominator);
        public static explicit operator double(BigRational b) => (double)(b.Numerator / b.Denominator);
        public static explicit operator float(BigRational b) => (float)(b.Numerator / b.Denominator);
        public static explicit operator decimal(BigRational b) => (decimal)(b.Numerator / b.Denominator);

        public int ToInt(IFormatProvider? provider) => (int)this;
        public double ToDouble(IFormatProvider? provider) => (double)this;
        public float ToSingle(IFormatProvider? provider) => (float)this;
        public decimal ToDecimal(IFormatProvider? provider) => (decimal)this;

    }
}
