using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ');
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];
            string city = personInfo[3];
            string[] beerInfo = Console.ReadLine().Split(' ');
            string beerName = beerInfo[0];
            int litersOfBeer = int.Parse(beerInfo[1]);
            string drunkOrNot = beerInfo[2];
            bool isDrunk = drunkOrNot == "drunk" ? true : false;
            string[] numbersInfo = Console.ReadLine().Split(' ');
            string name = numbersInfo[0];
            double doubleNum = double.Parse(numbersInfo[1]);
            string bank = numbersInfo[2];

            Threeuple<string, string,string> firstTuple = new Threeuple<string, string, string>(fullName,address,city);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(beerName, litersOfBeer,isDrunk);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(name, doubleNum,bank);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
