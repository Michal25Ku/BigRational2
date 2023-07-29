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
        public void Test_IEquatable_Equals_False(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            BigRational bigRational1 = new BigRational(numerator1, denominator1);
            BigRational bigRational2 = new BigRational(numerator2, denominator2);

            Assert.IsFalse(bigRational1.Equals(bigRational2));
            Assert.IsFalse(bigRational2.Equals(bigRational1));
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

            Assert.IsTrue(!x.Equals(y) || !y.Equals(z) || x.Equals(z));
        }
    }
}
