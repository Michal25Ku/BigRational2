using Microsoft.VisualStudio.TestTools.UnitTesting;
using RationalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalUnitTest
{
    [TestClass]
    public class BigRationalArithmeticUnitTests
    {
        [DataTestMethod]
        [DataRow(1, 2, 1, 2, 1, 1)]
        [DataRow(3, 2, 1, 3, 11, 6)]
        [DataRow(-1 ,2, 1, 2, 0, 1)]
        [DataRow(1, 5, -2, 4, -3, 10)]
        public void Test_Arithmetic_Plus_Method(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, test1.Plus(test2).Numerator);
            Assert.AreEqual(ed, test1.Plus(test2).Denominator);
        }

        [TestMethod]
        public void Test_Arithmetic_Plus_Method_NaN()
        {
            BigRational test1 = new BigRational();
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, test1.Plus(test2).Numerator);
            Assert.AreEqual(0, test1.Plus(test2).Denominator);
        }

        [DataTestMethod]
        [DataRow(10, 0, 1, 2, 1, 0)]
        [DataRow(-3, 0, 1, 3, -1, 0)]
        [DataRow(10, 0, 1, 0, 1, 0)]
        [DataRow(-1, 0, -2, 0, -1, 0)]
        [DataRow(1, 0, -2, 0, 0, 1)]
        public void Test_Arithmetic_Plus_Method_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, test1.Plus(test2).Numerator);
            Assert.AreEqual(ed, test1.Plus(test2).Denominator);
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 2, 1, 1)]
        [DataRow(3, 2, 1, 3, 11, 6)]
        [DataRow(-1, 2, 1, 2, 0, 1)]
        [DataRow(1, 5, -2, 4, -3, 10)]
        public void Test_Arithmetic_Plus_Static_Method(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            BigRational sum = BigRational.Sum(test1, test2);

            Assert.AreEqual(en, sum.Numerator);
            Assert.AreEqual(ed, sum.Denominator);
        }

        [TestMethod]
        public void Test_Arithmetic_Plus_Static_Method_Many_Parameters()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 4);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational sum = BigRational.Sum(test1, test2, test3, test4, test5);

            Assert.AreEqual(1567, sum.Numerator);
            Assert.AreEqual(420, sum.Denominator);
        }

        [TestMethod]
        public void Test_Arithmetic_Plus_Static_Method_Many_Parameters_With_NaN()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(0, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational sum = BigRational.Sum(test1, test2, test3, test4, test5);

            Assert.AreEqual(0, sum.Numerator);
            Assert.AreEqual(0, sum.Denominator);
        }

        [TestMethod]
        public void Test_Arithmetic_Plus_Static_Method_Many_Parameters_With_Infinity()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(4, 0);

            BigRational sum = BigRational.Sum(test1, test2, test3, test4, test5);

            Assert.AreEqual(1, sum.Numerator);
            Assert.AreEqual(0, sum.Denominator);
        }
    }
}
