using Microsoft.VisualStudio.TestTools.UnitTesting;
using RationalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RationalUnitTest
{
    
    [TestClass]
    public class BigRationalArithmeticUnitTests
    {
        #region Plus
        [DataTestMethod, TestCategory("Plus")]
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

        [TestMethod, TestCategory("Plus")]
        public void Test_Arithmetic_Plus_Method_NaN()
        {
            BigRational test1 = new BigRational();
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, test1.Plus(test2).Numerator);
            Assert.AreEqual(0, test1.Plus(test2).Denominator);
        }

        [DataTestMethod, TestCategory("Plus")]
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

        [DataTestMethod, TestCategory("Plus")]
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

        [TestMethod, TestCategory("Plus")]
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

        [TestMethod, TestCategory("Plus")]
        public void Test_Arithmetic_Sum_Static_Method_Many_Parameters_With_NaN()
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

        [TestMethod, TestCategory("Plus")]
        public void Test_Arithmetic_Sum_Static_Method_Many_Parameters_With_Infinity()
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

        [DataTestMethod, TestCategory("Plus")]
        [DataRow(1, 2, 1, 2, 1, 1)]
        [DataRow(3, 2, 1, 3, 11, 6)]
        [DataRow(-1, 2, 1, 2, 0, 1)]
        [DataRow(1, 5, -2, 4, -3, 10)]
        public void Test_Arithmetic_Plus_Operator(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, (test1 + test2).Numerator);
            Assert.AreEqual(ed, (test1 + test2).Denominator);
        }

        [TestMethod, TestCategory("Plus")]
        public void Test_Arithmetic_Plus_Operator_NaN()
        {
            BigRational test1 = new BigRational();
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, (test1 + test2).Numerator);
            Assert.AreEqual(0, (test1 + test2).Denominator);
        }

        [DataTestMethod, TestCategory("Plus")]
        [DataRow(10, 0, 1, 2, 1, 0)]
        [DataRow(-3, 0, 1, 3, -1, 0)]
        [DataRow(10, 0, 1, 0, 1, 0)]
        [DataRow(-1, 0, -2, 0, -1, 0)]
        [DataRow(1, 0, -2, 0, 0, 1)]
        public void Test_Arithmetic_Plus_Operator_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, (test1 + test2).Numerator);
            Assert.AreEqual(ed, (test1 + test2).Denominator);
        }
        #endregion
        #region Substract
        [DataTestMethod, TestCategory("Substract")]
        [DataRow(1, 2, 1, 2, 0, 1)]
        [DataRow(3, 2, 1, 3, 7, 6)]
        [DataRow(-1, 2, 1, 2, -1, 1)]
        [DataRow(1, 5, -2, 4, 7, 10)]
        public void Test_Arithmetic_Substract_Method(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, test1.Substract(test2).Numerator);
            Assert.AreEqual(ed, test1.Substract(test2).Denominator);
        }

        [TestMethod, TestCategory("Substract")]
        public void Test_Arithmetic_Substract_Method_NaN()
        {
            BigRational test1 = new BigRational();
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, test1.Substract(test2).Numerator);
            Assert.AreEqual(0, test1.Substract(test2).Denominator);
        }

        [DataTestMethod, TestCategory("Substract")]
        [DataRow(10, 0, 1, 2, 1, 0)]
        [DataRow(-3, 0, 1, 3, -1, 0)]
        [DataRow(10, 0, 1, 0, 0, 1)]
        [DataRow(-1, 0, -2, 0, 0, 1)]
        [DataRow(1, 0, -2, 0, 1, 0)]
        public void Test_Arithmetic_Substract_Method_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, test1.Substract(test2).Numerator);
            Assert.AreEqual(ed, test1.Substract(test2).Denominator);
        }

        [DataTestMethod, TestCategory("Substract")]
        [DataRow(1, 2, 1, 2, 0, 1)]
        [DataRow(3, 2, 1, 3, 7, 6)]
        [DataRow(-1, 2, 1, 2, -1, 1)]
        [DataRow(1, 5, -2, 4, 7, 10)]
        public void Test_Arithmetic_Devide_Static_Method(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            BigRational dev = BigRational.Devide(test1, test2);

            Assert.AreEqual(en, dev.Numerator);
            Assert.AreEqual(ed, dev.Denominator);
        }

        [TestMethod, TestCategory("Substract")]
        public void Test_Arithmetic_Devide_Static_Method_Many_Parameters()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 4);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational dev = BigRational.Devide(test1, test2, test3, test4, test5);

            Assert.AreEqual(-1483, dev.Numerator);
            Assert.AreEqual(420, dev.Denominator);
        }

        [TestMethod, TestCategory("Substract")]
        public void Test_Arithmetic_Devide_Static_Method_Many_Parameters_With_NaN()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(0, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational dev = BigRational.Devide(test1, test2, test3, test4, test5);

            Assert.AreEqual(0, dev.Numerator);
            Assert.AreEqual(0, dev.Denominator);
        }

        [TestMethod, TestCategory("Substract")]
        public void Test_Arithmetic_Devide_Static_Method_Many_Parameters_With_Infinity()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(4, 0);

            BigRational dev = BigRational.Devide(test1, test2, test3, test4, test5);

            Assert.AreEqual(-1, dev.Numerator);
            Assert.AreEqual(0, dev.Denominator);
        }

        [DataTestMethod, TestCategory("Substract")]
        [DataRow(1, 2, 1, 2, 0, 1)]
        [DataRow(3, 2, 1, 3, 7, 6)]
        [DataRow(-1, 2, 1, 2, -1, 1)]
        [DataRow(1, 5, -2, 4, 7, 10)]
        public void Test_Arithmetic_Substract_Operator(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, (test1 - test2).Numerator);
            Assert.AreEqual(ed, (test1 - test2).Denominator);
        }

        [TestMethod, TestCategory("Substract")]
        public void Test_Arithmetic_Substract_Operator_NaN()
        {
            BigRational test1 = new BigRational();
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, (test1 - test2).Numerator);
            Assert.AreEqual(0, (test1 - test2).Denominator);
        }

        [DataTestMethod, TestCategory("Substract")]
        [DataRow(10, 0, 1, 2, 1, 0)]
        [DataRow(-3, 0, 1, 3, -1, 0)]
        [DataRow(10, 0, 1, 0, 0, 1)]
        [DataRow(-1, 0, -2, 0, 0, 1)]
        [DataRow(1, 0, -2, 0, 1, 0)]
        public void Test_Arithmetic_Substract_Operator_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, (test1 - test2).Numerator);
            Assert.AreEqual(ed, (test1 - test2).Denominator);
        }
        #endregion
        #region Multiply
        [DataTestMethod, TestCategory("Multiply")]
        [DataRow(1, 2, 1, 2)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -2, 4)]
        public void Test_Arithmetic_Multiply_Method(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational inverseTest1 = new BigRational(b1d, b1n);

            BigRational test2 = new BigRational(b2n, b2d);
            BigRational inverseTest2 = new BigRational(b2d, b2n);

            Assert.IsTrue(new BigRational(b1n * b2n, b1d * b2d) ==  test1.Multiply(test2));
            // neutral element
            Assert.IsTrue((test1 * 1) == (1 * test1) && ((1 * test1) == test1) && ((test1 * 1) == test1));
            Assert.IsTrue((test2 * 1) == (1 * test2) && ((1 * test2) == test2) && ((test2 * 1) == test2));
            // commutative
            Assert.IsTrue(test1.Multiply(test2) == test2.Multiply(test1));
            // inverse element
            Assert.IsTrue((test1.Multiply(inverseTest1) == inverseTest1.Multiply(test1)) && (test1.Multiply(inverseTest1) == 1));
            Assert.IsTrue((test2.Multiply(inverseTest2) == inverseTest2.Multiply(test2)) && (test2.Multiply(inverseTest2) == 1));
        }

        [TestMethod, TestCategory("Multiply")]
        public void Test_Arithmetic_Multiply_Method_NaN()
        {
            BigRational test1 = new BigRational(1, 2);
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, test1.Multiply(test2).Numerator);
            Assert.AreEqual(0, test1.Multiply(test2).Denominator);
        }

        [DataTestMethod, TestCategory("Multiply")]
        [DataRow(10, 0, 1, 2, 1, 0)]
        [DataRow(-3, 0, 1, 3, -1, 0)]
        [DataRow(10, 0, 1, 0, 1, 0)]
        [DataRow(-1, 0, -2, 0, 1, 0)]
        [DataRow(1, 0, -2, 0, -1, 0)]
        [DataRow(1, 0, 0, 1, 0, 1)]
        public void Test_Arithmetic_Multiply_Method_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, test1.Multiply(test2).Numerator);
            Assert.AreEqual(ed, test1.Multiply(test2).Denominator);
        }

        [DataTestMethod, TestCategory("Multiply")]
        [DataRow(1, 2, 1, 2)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -2, 4)]
        public void Test_Arithmetic_Multiply_Static_Method(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational inverseTest1 = new BigRational(b1d, b1n);

            BigRational test2 = new BigRational(b2n, b2d);
            BigRational inverseTest2 = new BigRational(b2d, b2n);

            Assert.IsTrue(new BigRational(b1n * b2n, b1d * b2d) == BigRational.Multiply(test1, test2));
            // neutral element
            Assert.IsTrue(BigRational.Multiply(test1, 1) == BigRational.Multiply(1, test1) && (BigRational.Multiply(test1, 1) == test1));
            Assert.IsTrue(BigRational.Multiply(test2, 1) == BigRational.Multiply(1, test2) && (BigRational.Multiply(test2, 1) == test2));
            // commutative
            Assert.IsTrue(BigRational.Multiply(test1, test2) == BigRational.Multiply(test2, test1));
            // inverse element
            Assert.IsTrue((BigRational.Multiply(test1, inverseTest1) == BigRational.Multiply(inverseTest1, test1)) && (BigRational.Multiply(test1, inverseTest1) == 1));
            Assert.IsTrue((BigRational.Multiply(test2, inverseTest2) == BigRational.Multiply(inverseTest2, test2)) && (BigRational.Multiply(test2, inverseTest2) == 1));
        }

        [TestMethod, TestCategory("Multiply")]
        public void Test_Arithmetic_Multiply_Static_Method_Many_Parameters()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 4);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational mult = BigRational.Multiply(test1, test2, test3, test4, test5);

            Assert.AreEqual(-1, mult.Numerator);
            Assert.AreEqual(315, mult.Denominator);
        }

        [TestMethod, TestCategory("Multiply")]
        public void Test_Arithmetic_Multiply_Static_Method_Many_Parameters_With_NaN()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(0, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational mult = BigRational.Multiply(test1, test2, test3, test4, test5);

            Assert.AreEqual(0, mult.Numerator);
            Assert.AreEqual(0, mult.Denominator);
        }

        [TestMethod, TestCategory("Multiply")]
        public void Test_Arithmetic_Multiply_Static_Method_Many_Parameters_With_Infinity()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(4, 0);

            BigRational mult = BigRational.Multiply(test1, test2, test3, test4, test5);

            Assert.AreEqual(1, mult.Numerator);
            Assert.AreEqual(0, mult.Denominator);
        }

        [DataTestMethod, TestCategory("Multiply")]
        [DataRow(1, 2, 1, 2)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -2, 4)]
        public void Test_Arithmetic_Multiply_Operator(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational inverseTest1 = new BigRational(b1d, b1n);

            BigRational test2 = new BigRational(b2n, b2d);
            BigRational inverseTest2 = new BigRational(b2d, b2n);

            Assert.IsTrue(new BigRational(b1n * b2n, b1d * b2d) == (test1 * test2));
            // neutral element
            Assert.IsTrue((test1 * 1) == (1 * test1) && ((1 * test1) == test1) && ((test1 * 1) == test1));
            Assert.IsTrue((test2 * 1) == (1 * test2) && ((1 * test2) == test2) && ((test2 * 1) == test2));
            // commutative
            Assert.IsTrue((test1 * test2) == (test2 * test1));
            // inverse element
            Assert.IsTrue(((test1 * inverseTest1) == (inverseTest1 * test1)) && ((test1 * inverseTest1) == 1));
            Assert.IsTrue(((test2 * inverseTest2) == (inverseTest2 * test2)) && ((test2 * inverseTest2) == 1));
        }

        [TestMethod, TestCategory("Multiply")]
        public void Test_Arithmetic_Multiply_Operator_NaN()
        {
            BigRational test1 = new BigRational();
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, (test1 * test2).Numerator);
            Assert.AreEqual(0, (test1 * test2).Denominator);
        }

        [DataTestMethod, TestCategory("Multiply")]
        [DataRow(10, 0, 1, 2, 1, 0)]
        [DataRow(-3, 0, 1, 3, -1, 0)]
        [DataRow(10, 0, 1, 0, 1, 0)]
        [DataRow(-1, 0, -2, 0, 1, 0)]
        [DataRow(1, 0, -2, 0, -1, 0)]
        [DataRow(1, 0, 0, 1, 0, 1)]
        public void Test_Arithmetic_Multiply_Operator_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, (test1 * test2).Numerator);
            Assert.AreEqual(ed, (test1 * test2).Denominator);
        }
        #endregion
        #region Division
        [DataTestMethod, TestCategory("Division")]
        [DataRow(1, 2, 1, 2)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -2, 4)]
        public void Test_Arithmetic_Division_Method(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational test1 = new BigRational(b1n, b1d);

            BigRational test2 = new BigRational(b2n, b2d);

            Assert.IsTrue(new BigRational(b1n * b2d, b1d * b2n) == test1.Division(test2));
            // neutral element
            Assert.IsTrue((test1 * 1) == (1 * test1) && ((1 * test1) == test1) && ((test1 * 1) == test1));
            Assert.IsTrue((test2 * 1) == (1 * test2) && ((1 * test2) == test2) && ((test2 * 1) == test2));
            // commutative
            Assert.IsTrue(test1.Multiply(test2) == test2.Multiply(test1));
            // inverse element
            Assert.IsTrue((test1.Division(test1) == 1) && (test1.Division(1) == test1));
            Assert.IsTrue((test2.Division(test2) == 1) && (test2.Division(1) == test2));
        }

        [TestMethod, TestCategory("Division")]
        public void Test_Arithmetic_Division_Method_NaN()
        {
            BigRational test1 = new BigRational(1, 2);
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, test1.Division(test2).Numerator);
            Assert.AreEqual(0, test1.Division(test2).Denominator);
        }

        [DataTestMethod, TestCategory("Division")]
        [DataRow(10, 0, 1, 2, 0, 0)]
        [DataRow(-3, 0, 1, 3, 0, 0)]
        [DataRow(10, 0, 1, 0, 0, 0)]
        [DataRow(-1, 0, -2, 0, 0, 0)]
        [DataRow(1, 0, -2, 0, 0, 0)]
        [DataRow(1, 0, 0, 1, 0, 0)]
        public void Test_Arithmetic_Division_Method_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, test1.Division(test2).Numerator);
            Assert.AreEqual(ed, test1.Division(test2).Denominator);
        }

        [DataTestMethod, TestCategory("Division")]
        [DataRow(1, 2, 1, 2)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -2, 4)]
        public void Test_Arithmetic_Division_Static_Method(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational inverseTest1 = new BigRational(b1d, b1n);

            BigRational test2 = new BigRational(b2n, b2d);
            BigRational inverseTest2 = new BigRational(b2d, b2n);

            Assert.IsTrue(new BigRational(b1n * b2d, b1d * b2n) == BigRational.Division(test1, test2));
            // neutral element
            Assert.IsTrue(BigRational.Multiply(test1, 1) == BigRational.Multiply(1, test1) && (BigRational.Multiply(test1, 1) == test1));
            Assert.IsTrue(BigRational.Multiply(test2, 1) == BigRational.Multiply(1, test2) && (BigRational.Multiply(test2, 1) == test2));
            // commutative
            Assert.IsTrue(BigRational.Multiply(test1, test2) == BigRational.Multiply(test2, test1));
            // inverse element
            Assert.IsTrue((BigRational.Division(test1, test1) == 1) && (BigRational.Division(test1, 1) == test1));
            Assert.IsTrue((BigRational.Division(test2, test2) == 1) && (BigRational.Division(test2, 1) == test2));
        }

        [TestMethod, TestCategory("Division")]
        public void Test_Arithmetic_Division_Static_Method_Many_Parameters()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 4);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational div = BigRational.Division(test1, test2, test3, test4, test5);

            Assert.AreEqual(-63, div.Numerator);
            Assert.AreEqual(20, div.Denominator);
        }

        [TestMethod, TestCategory("Division")]
        public void Test_Arithmetic_Division_Static_Method_Many_Parameters_With_NaN()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(0, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(1, 21);

            BigRational div = BigRational.Division(test1, test2, test3, test4, test5);

            Assert.AreEqual(0, div.Numerator);
            Assert.AreEqual(0, div.Denominator);
        }

        [TestMethod, TestCategory("Division")]
        public void Test_Arithmetic_Division_Static_Method_Many_Parameters_With_Infinity()
        {
            BigRational test1 = new BigRational(1, 10);
            BigRational test2 = new BigRational(-2, 3);
            BigRational test3 = new BigRational(1, 0);
            BigRational test4 = new BigRational(4, 1);
            BigRational test5 = new BigRational(4, 0);

            BigRational div = BigRational.Division(test1, test2, test3, test4, test5);

            Assert.AreEqual(0, div.Numerator);
            Assert.AreEqual(0, div.Denominator);
        }

        [DataTestMethod, TestCategory("Division")]
        [DataRow(1, 2, 1, 2)]
        [DataRow(3, 2, 1, 3)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -2, 4)]
        public void Test_Arithmetic_Division_Operator(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational inverseTest1 = new BigRational(b1d, b1n);

            BigRational test2 = new BigRational(b2n, b2d);
            BigRational inverseTest2 = new BigRational(b2d, b2n);

            Assert.IsTrue(new BigRational(b1n * b2d, b1d * b2n) == (test1 / test2));
            // neutral element
            Assert.IsTrue((test1 * 1) == (1 * test1) && ((1 * test1) == test1) && ((test1 * 1) == test1));
            Assert.IsTrue((test2 * 1) == (1 * test2) && ((1 * test2) == test2) && ((test2 * 1) == test2));
            // commutative
            Assert.IsTrue((test1 * test2) == (test2 * test1));
            // inverse element
            Assert.IsTrue(((test1 / test1) == 1) && ((test1 / 1) == test1));
            Assert.IsTrue(((test2 / test2) == 1) && ((test2 / 1) == test2));
        }

        [TestMethod, TestCategory("Division")]
        public void Test_Arithmetic_Division_Operator_NaN()
        {
            BigRational test1 = new BigRational();
            BigRational test2 = BigRational.NaN;

            Assert.AreEqual(0, (test1 / test2).Numerator);
            Assert.AreEqual(0, (test1 / test2).Denominator);
        }

        [DataTestMethod, TestCategory("Division")]
        [DataRow(10, 0, 1, 2, 0, 0)]
        [DataRow(-3, 0, 1, 3, 0, 0)]
        [DataRow(10, 0, 1, 0, 0, 0)]
        [DataRow(-1, 0, -2, 0, 0, 0)]
        [DataRow(1, 0, -2, 0, 0, 0)]
        [DataRow(1, 0, 0, 1, 0, 0)]
        public void Test_Arithmetic_Division_Operator_Infinity(int b1n, int b1d, int b2n, int b2d, int en, int ed)
        {
            BigRational test1 = new BigRational(b1n, b1d);
            BigRational test2 = new BigRational(b2n, b2d);

            Assert.AreEqual(en, (test1 / test2).Numerator);
            Assert.AreEqual(ed, (test1 / test2).Denominator);
        }
        #endregion
        #region Inverse
        [DataTestMethod, TestCategory("Inversion")]
        [DataRow(1, 2, -1, 2)]
        [DataRow(3, 2, -3, 2)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -1, 5)]
        public void Test_Arithmetic_Inverse_Method(int bn, int bd, int en, int ed)
        {
            BigRational test = new BigRational(bn, bd);

            Assert.AreEqual(en, test.Inverse().Numerator);
            Assert.AreEqual(ed, test.Inverse().Denominator);
        }

        [TestMethod, TestCategory("Inversion")]
        public void Test_Arithmetic_Inverse_Method_With_NaN()
        {
            BigRational test = new BigRational(0, 0);

            Assert.AreEqual(0, test.Inverse().Numerator);
            Assert.AreEqual(0, test.Inverse().Denominator);
        }

        [DataTestMethod, TestCategory("Inversion")]
        [DataRow(1, 0, -1, 0)]
        [DataRow(-3, 0, 1, 0)]
        public void Test_Arithmetic_Inverse_Method_With_Infinity(int bn, int bd, int en, int ed)
        {
            BigRational test = new BigRational(bn, bd);

            Assert.AreEqual(en, test.Inverse().Numerator);
            Assert.AreEqual(ed, test.Inverse().Denominator);
        }

        [DataTestMethod, TestCategory("Inversion")]
        [DataRow(1, 2, -1, 2)]
        [DataRow(3, 2, -3, 2)]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(1, 5, -1, 5)]
        [DataRow(-1, -5, -1, 5)]
        [DataRow(1, -5, 1, 5)]
        public void Test_Arithmetic_Inverse_Operator(int bn, int bd, int en, int ed)
        {
            BigRational test = new BigRational(bn, bd);
            BigRational result = -test;

            Assert.AreEqual(en, result.Numerator);
            Assert.AreEqual(ed, result.Denominator);
        }

        [TestMethod, TestCategory("Inversion")]
        public void Test_Arithmetic_Inverse_Operator_With_NaN()
        {
            BigRational test = new BigRational(0, 0);

            Assert.AreEqual(0, -test.Numerator);
            Assert.AreEqual(0, -test.Denominator);
        }

        [DataTestMethod, TestCategory("Inversion")]
        [DataRow(1, 0, -1, 0)]
        [DataRow(-3, 0, 1, 0)]
        public void Test_Arithmetic_Inverse_Operator_With_Infinity(int bn, int bd, int en, int ed)
        {
            BigRational test = new BigRational(bn, bd);

            Assert.AreEqual(en, -test.Numerator);
            Assert.AreEqual(ed, -test.Denominator);
        }
        #endregion
    }
}
