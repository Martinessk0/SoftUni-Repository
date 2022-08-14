using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double max = double.MinValue;
            double volume = 0;
            string name = "";
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                volume = (Math.PI) * (Math.Pow(radius,2) )* height;
                if (max<=volume)
                {
                    max = volume;
                    name = model;
                }
            }

            Console.WriteLine(name);
        }
    }
}
