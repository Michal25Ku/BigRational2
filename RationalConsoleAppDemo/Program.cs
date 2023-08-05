using RationalLib;
using System.Numerics;
using static System.Console;

namespace RationalConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigRational b1 = new BigRational(1, 2);
            BigRational b2 = new BigRational(2, 3);

            Console.WriteLine(b1.Multiply(b2));
        }
    }
}