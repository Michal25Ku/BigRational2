using RationalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalUnitTest
{
    [TestClass]
    public class BigRationalRelationsUnitTests
    {
        [TestMethod]
        public void Test_IComparable_Object_Are_Equal()
        {
            BigRational A = new BigRational();

            Assert.AreEqual(0, A.CompareTo(A));
        }

        [TestMethod]
        public void Test_IComparable_Symmetry()
        {
            BigRational A = new BigRational();
            BigRational B = new BigRational();

            Assert.AreEqual(0, A.CompareTo(B));
            Assert.AreEqual(0, B.CompareTo(A));
        }

        [TestMethod]
        public void Test_IComparable_Transitivity()
        {
            BigRational A = new BigRational();
            BigRational B = new BigRational();
            BigRational C = new BigRational();

            Assert.AreEqual(0, A.CompareTo(B));
            Assert.AreEqual(0, B.CompareTo(C));
            Assert.AreEqual(0, C.CompareTo(A));
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 3)]
        [DataRow(3, 1, 1, 3)]
        [DataRow(-1, -3, -1, 2)]
        [DataRow(1, 3, -1, 3)]
        [DataRow(10, 5, 5, 5)]
        [DataRow(5, 10, 0, 0)]
        [DataRow(5, 0, -12, 0)]
        public void Test_IComparable_CompareTo_More_Than_0(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational bigRationalA = new BigRational(b1n, b1d);
            BigRational bigRationalB = new BigRational(b2n, b2d);

            Assert.IsTrue(bigRationalA.CompareTo(bigRationalB) < 0);
        }

        [DataTestMethod]
        [DataRow(1, 3, 1, 2)]
        [DataRow(1, 3, 3, 1)]
        [DataRow(-1, 2, -1, -3)]
        [DataRow(-1, 3, 1, 3)]
        [DataRow(5, 5, 10, 5)]
        [DataRow(0, 0, 5, 10)]
        [DataRow(-5, 0, 12, 0)]
        public void Test_IComparable_CompareTo_Less_Than_0(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational bigRationalA = new BigRational(b1n, b1d);
            BigRational bigRationalB = new BigRational(b2n, b2d);

            Assert.IsTrue(bigRationalA.CompareTo(bigRationalB) < 0);
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 3)]
        [DataRow(3, 1, 1, 3)]
        [DataRow(-1, -3, -1, 2)]
        [DataRow(1, 3, -1, 3)]
        [DataRow(10, 5, 5, 5)]
        [DataRow(5, 10, 0, 0)]
        [DataRow(5, 0, -12, 0)]
        public void Test_IComparable_Operator_More(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational bigRationalA = new BigRational(b1n, b1d);
            BigRational bigRationalB = new BigRational(b2n, b2d);

            Assert.IsTrue(bigRationalA > bigRationalB);
        }

        [DataTestMethod]
        [DataRow(1, 3, 1, 2)]
        [DataRow(1, 3, 3, 1)]
        [DataRow(-1, 2, -1, -3)]
        [DataRow(-1, 3, 1, 3)]
        [DataRow(5, 5, 10, 5)]
        [DataRow(0, 0, 5, 10)]
        [DataRow(-5, 0, 12, 0)]
        public void Test_IComparable_Operator_Less(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational bigRationalA = new BigRational(b1n, b1d);
            BigRational bigRationalB = new BigRational(b2n, b2d);

            Assert.IsTrue(bigRationalA < bigRationalB);
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 3)]
        [DataRow(3, 1, 1, 3)]
        [DataRow(3, 3, 3, 3)]
        [DataRow(-1, -3, -1, 2)]
        [DataRow(1, 3, -1, 3)]
        [DataRow(10, 5, 5, 5)]
        [DataRow(5, 6, 5, 6)]
        [DataRow(5, 10, 0, 0)]
        [DataRow(5, 0, -12, 0)]
        public void Test_IComparable_Operator_More_And_Equals(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational bigRationalA = new BigRational(b1n, b1d);
            BigRational bigRationalB = new BigRational(b2n, b2d);

            Assert.IsTrue(bigRationalA >= bigRationalB);
        }

        [DataTestMethod]
        [DataRow(1, 3, 1, 2)]
        [DataRow(1, 3, 3, 1)]
        [DataRow(-1, 2, -1, -3)]
        [DataRow(3, 3, 3, 3)]
        [DataRow(-1, 3, 1, 3)]
        [DataRow(5, 5, 10, 5)]
        [DataRow(5, 6, 5, 6)]
        [DataRow(0, 0, 5, 10)]
        [DataRow(-5, 0, 12, 0)]
        public void Test_IComparable_Operator_Less_And_Equals(int b1n, int b1d, int b2n, int b2d)
        {
            BigRational bigRationalA = new BigRational(b1n, b1d);
            BigRational bigRationalB = new BigRational(b2n, b2d);

            Assert.IsTrue(bigRationalA <= bigRationalB);
        }
    }
}
