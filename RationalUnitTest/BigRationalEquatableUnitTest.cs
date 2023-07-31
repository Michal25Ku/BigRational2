using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RationalLib;

namespace RationalUnitTest
{
    [TestClass]
    public class BigRationalEquatableUnitTest
    {
        [DataTestMethod]
        [DataRow(1, 3, 1, 3)]
        [DataRow(3, 1, 3, 1)]
        [DataRow(-1, -3, 1, 3)]
        [DataRow(1, -3, -1, 3)]
        [DataRow(0, 3, 0, 1)]
        [DataRow(2, 6, 1, 3)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(12312, 0, 121, 0)]
        [DataRow(-343241, 0, -1231, 0)]
        public void Test_IEquatable_Equals_True(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            BigRational bigRational1 = new BigRational(numerator1, denominator1);
            BigRational bigRational2 = new BigRational(numerator2, denominator2);

            Assert.IsTrue(bigRational1.Equals(bigRational2));
            Assert.IsTrue(bigRational2.Equals(bigRational1));
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 3)]
        [DataRow(3, 1, 1, 3)]
        [DataRow(-1, -3, -1, 3)]
        [DataRow(1, -3, -1, -3)]
        [DataRow(5, 10, 1, 5)]
        [DataRow(5, 10, 0, 0)]
        [DataRow(-5, 0, 1213, 0)]
        [DataRow(5, 10, -12, 0)]
        public void Test_IEquatable_Equals_False(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            BigRational bigRational1 = new BigRational(numerator1, denominator1);
            BigRational bigRational2 = new BigRational(numerator2, denominator2);

            Assert.IsFalse(bigRational1.Equals(bigRational2));
            Assert.IsFalse(bigRational2.Equals(bigRational1));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_OtherType()
        {
            BigRational b = new BigRational();
            var anonymousTypeVariable = new { x = 0, y = 1 };

            Assert.IsFalse(b.Equals(anonymousTypeVariable));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_Maneuverability_Test()
        {
            BigRational b = new BigRational();

            Assert.IsTrue(b.Equals((object)b));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_Symmetry_Test()
        {
            BigRational x = new BigRational(1, 2);
            BigRational y = new BigRational(x.Numerator, x.Denominator);

            Assert.IsTrue(x.Equals(y));
            Assert.IsTrue(y.Equals(x));
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 2, 1, 2)]
        [DataRow(1, 2, 2, 4, 3, 6)]
        [DataRow(-1, 2, 2, -4, -3, 6)]
        public void Test_IEquatable_Equals_Transitivity_Test(int u1l, int u1m, int u2l, int u2m, int u3l, int u3m)
        {
            BigRational x = new(u1l, u1m);
            BigRational y = new(u2l, u2m);
            BigRational z = new(u3l, u3m);

            Assert.IsTrue(x.Equals(y));
            Assert.IsTrue(y.Equals(z));
            Assert.IsTrue(x.Equals(z));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_NaN()
        {
            BigRational bigRational1 = BigRational.NaN;
            BigRational bigRational2 = new BigRational(12, 0);

            Assert.IsFalse(bigRational1.Equals(bigRational2));
            Assert.IsFalse(bigRational2.Equals(bigRational1));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_When_NaN_Equals_NaN()
        {
            BigRational bigRational1 = BigRational.NaN;
            BigRational bigRational2 = new BigRational(0, 0);

            Assert.IsTrue(bigRational1.Equals(bigRational2));
            Assert.IsTrue(bigRational2.Equals(bigRational1));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_PositiveInfinity()
        {
            BigRational bigRational1 = BigRational.positiveInfinity;
            BigRational bigRational2 = new BigRational(124, 0);

            Assert.IsTrue(bigRational1.Equals(bigRational2));
            Assert.IsTrue(bigRational2.Equals(bigRational1));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_NegativeInfinity()
        {
            BigRational bigRational1 = BigRational.negativeInfinity;
            BigRational bigRational2 = new BigRational(-1241, 0);

            Assert.IsTrue(bigRational1.Equals(bigRational2));
            Assert.IsTrue(bigRational2.Equals(bigRational1));
        }

        [DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(3, 1)]
        [DataRow(-1, -3)]
        [DataRow(1, -3)]
        [DataRow(5, 10)]
        [DataRow(5, 10)]
        public void Test_IEquatable_Equals_Reference(int numerator, int denominator)
        {
            BigRational bigRational1 = new BigRational(numerator, denominator);
            BigRational bigRational2 = bigRational1;

            Assert.IsTrue(bigRational1.Equals(bigRational2));
            Assert.IsTrue(bigRational2.Equals(bigRational1));
        }

        [DataTestMethod]
        [DataRow(1, 3, 1, 3)]
        [DataRow(3, 1, 3, 1)]
        [DataRow(-1, -3, 1, 3)]
        [DataRow(1, -3, -1, 3)]
        [DataRow(0, 3, 0, 1)]
        [DataRow(2, 6, 1, 3)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(12312, 0, 121, 0)]
        [DataRow(-343241, 0, -1231, 0)]
        public void Test_IEquatable_Operator_True(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            BigRational bigRational1 = new BigRational(numerator1, denominator1);
            BigRational bigRational2 = new BigRational(numerator2, denominator2);

            Assert.IsTrue(bigRational1 == bigRational2);
            Assert.IsTrue(bigRational2 == bigRational1);
        }

        [DataTestMethod]
        [DataRow(1, 3, 1, 3)]
        [DataRow(3, 1, 3, 1)]
        [DataRow(-1, -3, 1, 3)]
        [DataRow(1, -3, -1, 3)]
        [DataRow(0, 3, 0, 1)]
        [DataRow(2, 6, 1, 3)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(12312, 0, 121, 0)]
        [DataRow(-343241, 0, -1231, 0)]
        public void Test_IEquatable_Operator_False(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            BigRational bigRational1 = new BigRational(numerator1, denominator1);
            BigRational bigRational2 = new BigRational(numerator2, denominator2);

            Assert.IsFalse(bigRational1 != bigRational2);
            Assert.IsFalse(bigRational2 != bigRational1);
        }

        [TestMethod]
        public void Test_IEquatable_Equals_Null()
        {
            BigRational bigRational1 = new BigRational(1, 5);

            Assert.IsFalse(bigRational1.Equals(null));
        }

        [TestMethod]
        public void Test_IEquatable_Operator_Null()
        {
            BigRational bigRational1 = new BigRational(1, 5);

            Assert.IsFalse(bigRational1 == null);
            Assert.IsFalse(null == bigRational1);
        }

        [DataTestMethod]
        [DataRow(1, 3, 1, 3, 1, 4)]
        [DataRow(3, 1, 3, 1, 3, 1)]
        [DataRow(-1, -3, 1, 3, 1, -3)]
        [DataRow(1, -3, -1, 3, -1, -3)]
        [DataRow(0, 3, 0, 1, 10, 0)]
        [DataRow(2, 6, 1, 3, 10, 30)]
        public void Test_IEquatable_Equals_Static(int numerator1, int denominator1, int numerator2, int denominator2, int numerator3, int denominator3)
        {
            BigRational x = new BigRational(numerator1, denominator1);
            BigRational y = new BigRational(numerator2, denominator2);
            BigRational z = new BigRational(numerator3, denominator3);

            Assert.IsTrue(!BigRational.Equals(x, y) || !BigRational.Equals(y, z) || BigRational.Equals(x, z));
        }

        [DataTestMethod]
        [DataRow(1, 3, 1, 3)]
        [DataRow(3, 1, 3, 1)]
        [DataRow(-1, -3, 1, 3)]
        [DataRow(1, -3, -1, 3)]
        [DataRow(0, 3, 0, 1)]
        [DataRow(2, 6, 1, 3)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(12312, 0, 121, 0)]
        [DataRow(-343241, 0, -1231, 0)]
        public void Test_IEquatable_Equals_Static_Operator(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            BigRational bigRational1 = new BigRational(numerator1, denominator1);
            BigRational bigRational2 = new BigRational(numerator2, denominator2);

            Assert.IsTrue(BigRational.Equals(bigRational1, bigRational2));
        }

        [TestMethod]
        public void Test_IEquatable_Equals_Static_Null()
        {
            BigRational x = new BigRational(1, 2);

            Assert.IsFalse(BigRational.Equals(x, null));
            Assert.IsFalse(BigRational.Equals(null, x));
            Assert.IsTrue(BigRational.Equals(null, null));
        }

        [DataTestMethod]
        [DataRow(3, 1, 3)]
        [DataRow(-3, 1, -3)]
        [DataRow(3, -1, -3)]
        [DataRow(10, 5, 2)]
        [DataRow(1, 1, 1)]
        public void Test_IEquatable_BigRational_Equals_int(int numerator, int denominator, int expected)
        {
            BigRational b = new BigRational(numerator, denominator);

            Assert.AreEqual(expected, b);
        }

        [DataTestMethod]
        [DataRow(1, 2, 0.5)]
        [DataRow(4, 20, 0.2)]
        [DataRow(18, 5, 3.6)]
        [DataRow(10, 5, 2.0)]
        [DataRow(1, 1, 1.0)]
        public void Test_IEquatable_BigRational_Equals_double(int numerator, int denominator, double expected)
        {
            BigRational b = new BigRational(numerator, denominator);

            Assert.AreEqual(expected, b);
        }
    }
}
