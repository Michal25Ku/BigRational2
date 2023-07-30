using RationalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalUnitTest
{
    [TestClass]
    public class BigRationalConversionsUnitTests
    {
        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(4, 2, 2)]
        [DataRow(-2, 1, 0)]
        [DataRow(-1, 2, 0)]
        [DataRow(-2, -1, 2)]
        [DataRow(2, -1, 0)]
        public void Test_Conversions_Explicit_To_Byte(int n, int d, int e)
        {
            BigRational b = new BigRational(n, d);
            byte l = (byte)b;
            Assert.AreEqual((byte)e, l);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(4, 2, 2)]
        [DataRow(-2, 1, -2)]
        [DataRow(-1, 2, 0)]
        [DataRow(-2, -1, 2)]
        [DataRow(2, -1, -2)]
        public void Test_Conversions_Explicit_To_Sbyte(int n, int d, int e)
        {
            BigRational b = new BigRational(n, d);
            sbyte l = (sbyte)b;
            Assert.AreEqual((sbyte)e, l);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(4, 2, 2)]
        [DataRow(-2, 1, -2)]
        [DataRow(-1, 2, 0)]
        [DataRow(-2, -1, 2)]
        [DataRow(2, -1, -2)]
        public void Test_Conversions_Explicit_To_Short(int n, int d, int e)
        {
            BigRational b = new BigRational(n, d);
            short l = (short)b;
            Assert.AreEqual((short)e, l);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(4, 2, 2)]
        [DataRow(-2, 1, 0)]
        [DataRow(-1, 2, 0)]
        [DataRow(-2, -1, 2)]
        [DataRow(2, -1, 0)]
        public void Test_Conversions_Explicit_To_Ushort(int n, int d, int e)
        {
            BigRational b = new BigRational(n, d);
            ushort l = (ushort)b;
            Assert.AreEqual((ushort)e, l);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(4, 2, 2)]
        [DataRow(-2, 1, 0)]
        [DataRow(-1, 2, 0)]
        [DataRow(-2, -1, 2)]
        [DataRow(2, -1, 0)]
        public void Test_Conversions_Explicit_To_Uint(int n, int d, int e)
        {
            BigRational b = new BigRational(n, d);
            uint l = (uint)b;
            Assert.AreEqual((uint)e, l);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(4, 2, 2)]
        [DataRow(-2, 1, -2)]
        [DataRow(-1, 2, 0)]
        [DataRow(-2, -1, 2)]
        [DataRow(2, -1, -2)]
        public void Test_Conversions_Explicit_To_Long(int n, int d, int e)
        {
            BigRational b = new BigRational(n, d);
            long l = (long)b;
            Assert.AreEqual((long)e, l);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0)]
        [DataRow(2, 2, 1)]
        [DataRow(4, 2, 2)]
        [DataRow(-2, 1, 0)]
        [DataRow(-1, 2, 0)]
        [DataRow(-2, -1, 2)]
        [DataRow(2, -1, 0)]
        public void Test_Conversions_Explicit_To_Ulong(int n, int d, int e)
        {
            BigRational b = new BigRational(n, d);
            ulong l = (ulong)b;
            Assert.AreEqual((ulong)e, l);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(4, 4)]
        public void Test_Conversions_Implicit_To_Byte(int n, int en)
        {
            BigRational b = n;
   
            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual((byte)1, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(4, 4)]
        [DataRow(-2, -2)]
        [DataRow(-1, -1)]
        public void Test_Conversions_Implicit_To_Sbyte(int n, int en)
        {
            BigRational b = n;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual((sbyte)1, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(4, 4)]
        [DataRow(-2, -2)]
        [DataRow(-1, -1)]
        public void Test_Conversions_Implicit_To_Short(int n, int en)
        {
            BigRational b = n;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual((short)1, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(4, 4)]
        public void Test_Conversions_Implicit_To_Ushort(int n, int en)
        {
            BigRational b = n;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual((ushort)1, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(4, 4)]
        public void Test_Conversions_Implicit_To_Uint(int n, int en)
        {
            BigRational b = n;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual((uint)1, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(4, 4)]
        public void Test_Conversions_Implicit_To_Ulong(int n, int en)
        {
            BigRational b = n;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual((ulong)1, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(4, 4)]
        [DataRow(-2, -2)]
        [DataRow(-1, -1)]
        public void Test_Conversions_Implicit_To_Long(int n, int en)
        {
            BigRational b = n;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual((long)1, b.Denominator);
        }
    }
}
