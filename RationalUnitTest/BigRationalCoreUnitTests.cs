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
            Assert.AreEqual(test.Numerator, expectedNumerator);
            Assert.AreEqual(test.Denominator, expectedDenominator);
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
            Assert.AreEqual(test.Numerator, expectedNumerator);
            Assert.AreEqual(test.Denominator, expectedDenominator);
        }

        [DataTestMethod]
        [DataRow(3, 3, 1)]
        [DataRow(10, 10, 1)]
        [DataRow(-12, -12, 1)]
        public void Test_Constructor_One_Parameter(int numerator, int expectedNumerator, int expectedDenominator)
        {
            BigRational test = new BigRational(numerator);
            Assert.AreEqual(test.Numerator, expectedNumerator);
            Assert.AreEqual(test.Denominator, expectedDenominator);
        }

        [TestMethod]
        public void Test_Default_Constructor()
        {
            BigRational test = new BigRational();
            Assert.AreEqual(test.Numerator, 0);
            Assert.AreEqual(test.Denominator, 1);
        }

        //[TestMethod]
        //public void Test_Constant_Fractions()
        //{
        //    BigRational test1 = BigRational.zero;
        //    BigRational test2 = BigRational.one;
        //    BigRational test3 = BigRational.half;
        //    BigRational test4 = BigRational.NaN;

        //    Assert.AreEqual(test1.Numerator, 0);
        //    Assert.AreEqual(test1.Denominator, 1);

        //    Assert.AreEqual(test2.Numerator, 1);
        //    Assert.AreEqual(test2.Denominator, 1);

        //    Assert.AreEqual(test3.Numerator, 1);
        //    Assert.AreEqual(test3.Denominator, 2);

        //    Assert.AreEqual(test4.Numerator, 0);
        //    Assert.AreEqual(test4.Denominator, 0);
        //}

        [TestMethod]
        public void Test_BigRational_ToString()
        {
            BigRational test1 = new BigRational(12, 2);
            BigRational test2 = new BigRational(1, -3);
            BigRational test3 = new BigRational(-1, -3);

            Assert.AreEqual(test1.ToString(), "<<6>>/<<1>>");
            Assert.AreEqual(test2.ToString(), "<<-1>>/<<3>>");
            Assert.AreEqual(test3.ToString(), "<<1>>/<<3>>");
        }

        //[TestMethod]
        //public void Test_BigRational_Is_NaN()
        //{
        //    BigRational test1 = new BigRational(0, 0);
        //    BigRational test2 = new BigRational(-1, 0);

        //    Assert.AreEqual(BigRational.IsNaN(test1), true);
        //    Assert.AreEqual(BigRational.IsNaN(test2), false);
        //}

        //[TestMethod]
        //public void Test_BigRational_Is_Infinity()
        //{
        //    BigRational test1 = new BigRational(0, 0);
        //    BigRational test2 = new BigRational(-1, 0);
        //    BigRational test3 = new BigRational(1, 0);
        //    BigRational test4 = new BigRational(1, 2);

        //    Assert.AreEqual(BigRational.IsInfinity(test1), false);
        //    Assert.AreEqual(BigRational.IsInfinity(test2), true);
        //    Assert.AreEqual(BigRational.IsInfinity(test3), true);
        //    Assert.AreEqual(BigRational.IsInfinity(test4), false);
        //}

        //[TestMethod]
        //public void Test_BigRational_Is_Positive_Infinity()
        //{
        //    BigRational test1 = new BigRational(0, 0);
        //    BigRational test2 = new BigRational(-1, 0);
        //    BigRational test3 = new BigRational(1, 0);
        //    BigRational test4 = new BigRational(1, 2);

        //    Assert.AreEqual(BigRational.IsPositiveInfinity(test1), false);
        //    Assert.AreEqual(BigRational.IsPositiveInfinity(test2), false);
        //    Assert.AreEqual(BigRational.IsPositiveInfinity(test3), true);
        //    Assert.AreEqual(BigRational.IsPositiveInfinity(test4), false);
        //}

        //[TestMethod]
        //public void Test_BigRational_Is_Negative_Infinity()
        //{
        //    BigRational test1 = new BigRational(0, 0);
        //    BigRational test2 = new BigRational(-1, 0);
        //    BigRational test3 = new BigRational(1, 0);
        //    BigRational test4 = new BigRational(1, 2);

        //    Assert.AreEqual(BigRational.IsNegativeInfinity(test1), false);
        //    Assert.AreEqual(BigRational.IsNegativeInfinity(test2), true);
        //    Assert.AreEqual(BigRational.IsNegativeInfinity(test3), false);
        //    Assert.AreEqual(BigRational.IsNegativeInfinity(test4), false);
        //}
    }
}