using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isPasswordLengthValid = LengthValid(password);
            bool isPasswordContainValidSymbols = ValidSymbols(password);
            bool isDigitInPasswordAtLeastTwo = ValidDigits(password);

            if (!isPasswordLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!isPasswordContainValidSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!isDigitInPasswordAtLeastTwo)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isPasswordLengthValid&&isPasswordContainValidSymbols&&isDigitInPasswordAtLeastTwo)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool LengthValid(string text)
        {
            return text.Length >= 6 && text.Length <= 10;
        }

        static bool ValidSymbols(string text)
        {
            
            foreach (var character in text)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    return false;
                }
            }

            return true;
        }

        static bool ValidDigits(string text)
        {
            int count = 0;
            foreach (var character in text)
            {
                if (char.IsDigit(character))
                {
                    count++;
                }
            }

            return count >= 2;
        }
    }
}
