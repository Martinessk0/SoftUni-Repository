using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ');
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string city = personInfo[2];
            string[] beerInfo = Console.ReadLine().Split(' ');
            string beerName = beerInfo[0];
            int litersOfBeer = int.Parse(beerInfo[1]);
            string[] numbersInfo = Console.ReadLine().Split(' ');
            int intNum = int.Parse(numbersInfo[0]);
            double doubleNum = double.Parse(numbersInfo[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(beerName, litersOfBeer);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}