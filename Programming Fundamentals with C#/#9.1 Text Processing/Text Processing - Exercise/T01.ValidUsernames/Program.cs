using System;

namespace T01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");
            foreach (var name in names)
            {
                if (name.Length >= 3 && name.Length <= 16)
                {
                    bool isNameValid = true;
                    foreach (var currChar in name)
                    {
                        if (!(char.IsLetterOrDigit(currChar) || (currChar=='-') || (currChar=='_')))
                        {
                            isNameValid = false;
                            break;
                        }
                    }
                    if (isNameValid)
                    {
                        Console.WriteLine(name);
                    }
                }
            }

        }
    }
}
