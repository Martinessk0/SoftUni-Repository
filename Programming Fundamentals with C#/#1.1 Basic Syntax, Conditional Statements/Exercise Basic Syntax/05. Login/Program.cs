using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length-1; i >=0; i--)
            {
                password = password + username[i];
            }

            string input = Console.ReadLine();
            int failCount = 0;
            while (input!=password)
            {
                if (input == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                if (failCount==3)
                {
                    
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
               
                failCount++;
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }
            if (input == password)
            {
                Console.WriteLine($"User {username} logged in.");
                
            }
        }
    }
}
