using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Calculations(type, a, b);
        }

        static void Calculations(string type,int a,int b)
        {
            int result = 0;
            if (type=="add")
            {
                result = a + b;
            }
            else if (type== "multiply")
            {
                result = a * b;
            }
            else if (type== "subtract")
            {
                result = a - b;
            }
            else if (type== "divide")
            {
                result = a / b;
            }

            Console.WriteLine(result);
        }
        
    }
}
