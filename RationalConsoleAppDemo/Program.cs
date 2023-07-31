using RationalLib;
using System.Numerics;
using static System.Console;

namespace RationalConsoleAppDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floatPlaces = BitConverter.GetBytes(decimal.GetBits((decimal)0.7)[3])[2];
            //new BigRational((BigInteger)(b * Math.Pow(10, floatPlaces)), (BigInteger)Math.Pow(10, floatPlaces));
            Console.WriteLine(Math.Round(0.7f * Math.Pow(10, floatPlaces)));
        }
    }
}