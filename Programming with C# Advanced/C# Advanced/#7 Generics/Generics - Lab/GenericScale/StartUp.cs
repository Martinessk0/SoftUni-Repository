using System;
using System.Threading;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<int>(3, 3);
            Console.WriteLine(scale.AreEqual());
        }
    }
}
