using RationalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [DataRow(3, 3, 1)]
        [DataRow(10, 5, 2)]
        [DataRow(3, 2, 1.5d)]
        [DataRow(-3, 2, -1.5d)]
        [DataRow(5, 10, 0.5d)]
        public void Test_Conversion_Explicite_To_Double(int numerator, int denominator, double resoult)
        {
            BigRational test = new BigRational(numerator, denominator);

            double y = (double)test;

            Assert.AreEqual(resoult, y);
        }

        [DataTestMethod]
        [DataRow(3, 3, 1)]
        [DataRow(10, 5, 2)]
        [DataRow(3, 2, 1.5f)]
        [DataRow(-3, 2, -1.5f)]
        [DataRow(5, 10, 0.5f)]
        public void Test_Conversion_Explicite_To_Single(int numerator, int denominator, float resoult)
        {
            BigRational test = new BigRational(numerator, denominator);

            double y = (double)test;

            Assert.AreEqual(resoult, y);
        }

        [DataTestMethod]
        [DataRow(3, 3, 1)]
        [DataRow(10, 5, 2)]
        [DataRow(3, 2, 1.5)]
        [DataRow(-3, 2, -1.5)]
        [DataRow(5, 10, 0.5)]
        public void Test_Conversion_Explicite_To_Decimal(int numerator, int denominator, double resoult)
        {
            BigRational test = new BigRational(numerator, denominator);

            decimal y = (decimal)test;

            Assert.AreEqual((decimal)resoult, y);
        }

        [DataTestMethod]
        [DataRow(3, 3, 1)]
        [DataRow(10, 5, 2)]
        [DataRow(3, 2, 1)]
        [DataRow(-3, 2, -1)]
        [DataRow(5, 10, 0)]
        public void Test_Conversion_Explicite_To_Int(int numerator, int denominator, int resoult)
        {
            BigRational test = new BigRational(numerator, denominator);

            int y = (int)test;

            Assert.AreEqual(resoult, y);
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

        [DataTestMethod]
        [DataRow(3.4f, 17, 5)]
        [DataRow(10, 10, 1)]
        [DataRow(1.1f, 11, 10)]
        [DataRow(0.7f, 7, 10)]
        [DataRow(0.9f, 9, 10)]
        [DataRow(1.3f, 13, 10)]
        [DataRow(-0.5f, -1, 2)]
        public void Test_Conversion_Implicite_BigRational_To_Float(float number, int en, int ed)
        {
            BigRational b = number;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual(ed, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(3.4, 17, 5)]
        [DataRow(10, 10, 1)]
        [DataRow(1.1, 11, 10)]
        [DataRow(0.7, 7, 10)]
        [DataRow(-0.5, -1, 2)]
        public void Test_Conversion_Implicite_BigRational_To_Double(double number, int en, int ed)
        {
            BigRational b = number;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual(ed, b.Denominator);
        }

        [DataTestMethod]
        [DataRow(3.4, 17, 5)]
        [DataRow(10, 10, 1)]
        [DataRow(1.1, 11, 10)]
        [DataRow(0.7, 7, 10)]
        [DataRow(-0.5, -1, 2)]
        public void Test_Conversion_Implicite_BigRational_To_Decimal(double number, int en, int ed)
        {
            BigRational b = (decimal)number;

            Assert.AreEqual(en, b.Numerator);
            Assert.AreEqual(ed, b.Denominator);
        }
    }
}
