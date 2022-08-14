using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //bool isPalindrome = Palindrome(input);
            while (input!="END")
            {
                Console.WriteLine(Palindrome(input));
                input = Console.ReadLine();
            }
        }

        static bool Palindrome(string input)
        {
            int currNumber = int.Parse(input);
            int number = currNumber;
            int reverse = 0;
            while (currNumber>0)
            {
                int lastDigit = currNumber % 10;
                reverse = reverse * 10 + lastDigit;
                currNumber /= 10;
            }

            if (number == reverse)
            {
                return true;
            }

            return false;
        }
    }
}
