using System;
using System.Text;

namespace T05.DigitsLettersAndOther
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string digit = "";
            string letters = "";
            string sybmols = "";
            foreach (char letter in input)
            {
                if (char.IsDigit(letter))
                {
                    digit += letter;
                }
                else if (char.IsLetter(letter))
                {
                    letters += letter;
                }
                else
                {
                    sybmols += letter;
                }
            }

            Console.WriteLine(digit);
            Console.WriteLine(letters);
            Console.WriteLine(sybmols);
        }
    }
}
