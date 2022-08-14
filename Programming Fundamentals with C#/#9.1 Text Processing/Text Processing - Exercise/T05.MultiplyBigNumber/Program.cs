using System;
using System.Numerics;

namespace T05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num1 = BigInteger.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            BigInteger bi = num1 * num2;
            Console.WriteLine(bi);
        }
    }
}
