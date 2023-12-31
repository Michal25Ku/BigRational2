using RationalLib;

namespace RationalUnitTest
{
    [TestClass]
    public class BigRationalCoreUnitTests
    {
        [DataTestMethod]
        [DataRow(1,3,1,3)]
        [DataRow(1,-3,-1,3)]
        [DataRow(-1,-3,1,3)]
        [DataRow(-1,3,-1,3)]
        [DataRow(0,3,0,1)]
        public void Test_Constructor_SimpleData(int numerator, int denominator, int expectedNumerator, int expectedDenominator)
        {
            BigRational test = new BigRational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, test.Numerator);
            Assert.AreEqual(expectedDenominator, test.Denominator);
        }

        [DataTestMethod]
        [DataRow(2, 4, 1, 2)]
        [DataRow(3, 4, 3, 4)]
        [DataRow(3, 27, 1, 9)]
        [DataRow(20, 4, 5, 1)]
        [DataRow(20, -4, -5, 1)]
        public void Test_Constructor_Reducing_Fractions(int numerator, int denominator, int expectedNumerator, int expectedDenominator)
        {
            BigRational test = new BigRational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, test.Numerator);
            Assert.AreEqual(expectedDenominator, test.Denominator);
        }

        [DataTestMethod]
        [DataRow(3, 3, 1)]
        [DataRow(10, 10, 1)]
        [DataRow(-12, -12, 1)]
        public void Test_Constructor_One_Parameter(int numerator, int expectedNumerator, int expectedDenominator)
        {
            BigRational test = new BigRational(numerator);
            Assert.AreEqual(expectedNumerator, test.Numerator);
            Assert.AreEqual(expectedDenominator, test.Denominator);
        }

        [TestMethod]
        public void Test_Default_Constructor()
        {
            BigRational test = new BigRational();
            Assert.AreEqual(0, test.Numerator);
            Assert.AreEqual(1, test.Denominator);
        }

        [DataTestMethod]
        [DataRow("1/2", 1, 2)]
        [DataRow("0/0", 0, 0)]
        [DataRow("4/6", 2, 3)]
        [DataRow("4/-6", -2, 3)]
        public void Test_Constructor_String_Parameter(string fraction, int expectedNumerator, int expectedDenominator)
        {
            BigRational test = new BigRational(fraction);

            Assert.AreEqual(expectedNumerator, test.Numerator);
            Assert.AreEqual(expectedDenominator, test.Denominator);
        }

        [DataTestMethod]
        [DataRow("l/1")]
        [DataRow("1/a")]
        [DataRow("0/0/1")]
        public void Test_Constructor_String_Parameter_Wrong_String(string fraction)
        {
            Action test = () => new BigRational(fraction);

            Assert.ThrowsException<ArgumentException>(test);
        }

        [TestMethod]
        public void Test_Constant_Fractions()
        {
            BigRational test1 = BigRational.zero;
            BigRational test2 = BigRational.one;
            BigRational test3 = BigRational.half;
            BigRational test4 = BigRational.NaN;

            Assert.AreEqual(0, test1.Numerator);
            Assert.AreEqual(1, test1.Denominator);

            Assert.AreEqual(1, test2.Numerator);
            Assert.AreEqual(1, test2.Denominator);

            Assert.AreEqual(1, test3.Numerator);
            Assert.AreEqual(2, test3.Denominator);

            Assert.AreEqual(0, test4.Numerator);
            Assert.AreEqual(0, test4.Denominator);
        }

        [TestMethod]
        public void Test_BigRational_Is_NaN()
        {
            BigRational test1 = new BigRational(0, 0);
            BigRational test2 = new BigRational(-1, 0);

            Assert.AreEqual(true, BigRational.IsNaN(test1));
            Assert.AreEqual(false, BigRational.IsNaN(test2));
        }

        [TestMethod]
        public void Test_BigRational_Is_Infinity()
        {
            BigRational test1 = new BigRational(0, 0);
            BigRational test2 = new BigRational(-1, 0);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(1, 2);

            Assert.AreEqual(false, BigRational.IsInfinity(test1));
            Assert.AreEqual(true, BigRational.IsInfinity(test2));
            Assert.AreEqual(true, BigRational.IsInfinity(test3));
            Assert.AreEqual(false, BigRational.IsInfinity(test4));
        }

        [TestMethod]
        public void Test_BigRational_Is_Positive_Infinity()
        {
            BigRational test1 = new BigRational(0, 0);
            BigRational test2 = new BigRational(-1, 0);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(1, 2);

            Assert.AreEqual(false, BigRational.IsPositiveInfinity(test1));
            Assert.AreEqual(false, BigRational.IsPositiveInfinity(test2));
            Assert.AreEqual(true, BigRational.IsPositiveInfinity(test3));
            Assert.AreEqual(false, BigRational.IsPositiveInfinity(test4));
        }

        [TestMethod]
        public void Test_BigRational_Is_Negative_Infinity()
        {
            BigRational test1 = new BigRational(0, 0);
            BigRational test2 = new BigRational(-1, 0);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(1, 2);

            Assert.AreEqual(false, BigRational.IsNegativeInfinity(test1));
            Assert.AreEqual(true, BigRational.IsNegativeInfinity(test2));
            Assert.AreEqual(false, BigRational.IsNegativeInfinity(test3));
            Assert.AreEqual(false, BigRational.IsNegativeInfinity(test4));
        }

        [TestMethod]
        public void Test_BigRational_Is_Finity()
        {
            BigRational test1 = new BigRational(0, 0);
            BigRational test2 = new BigRational(-1, 0);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(1, 2);

            Assert.AreEqual(false, BigRational.IsFinity(test1));
            Assert.AreEqual(false, BigRational.IsFinity(test2));
            Assert.AreEqual(false, BigRational.IsFinity(test3));
            Assert.AreEqual(true, BigRational.IsFinity(test4));
        }

        [DataTestMethod]
        [DataRow(12, 2, "6/1")]
        [DataRow(1, -3, "-1/3")]
        [DataRow(-1, -3, "1/3")]
        [DataRow(0, 0, "NaN")]
        [DataRow(-2, 0, "NEGATIVE_INFINITY")]
        [DataRow(4, 0, "POSITIVE_INFINITY")]
        public void Test_BigRational_ToString(int numerator, int denomitaor, string expected)
        {
            BigRational test = new BigRational(numerator, denomitaor);

            Assert.AreEqual(expected, test.ToString());
        }
    }
}