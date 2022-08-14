using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Engine
    {
        private List<IBuyer> repository;

        public Engine()
        {
            repository = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            FillRepository(n);

            string input = Console.ReadLine();
            while (input != "End")
            {
                IBuyer newBuyer =BuyFood(input,repository);
                newBuyer?.BuyFood();
                input = Console.ReadLine();
            }
            PrintFinalResult();
        }

        private void FillRepository(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] buyersInfo = Console.ReadLine().Split();
                string name = buyersInfo[0];
                int age = int.Parse(buyersInfo[1]);
                IBuyer buyer = null;
                if (buyersInfo.Length == 3)
                {
                    string group = buyersInfo[2];
                    buyer = new Rebel(name, age, group);
                }
                else if (buyersInfo.Length == 4)
                {
                    string id = buyersInfo[2];
                    string birthdate = buyersInfo[3];
                    buyer = new Citizen(id, name, age, birthdate);
                }
                if (buyer != null)
                {
                    repository.Add(buyer);
                }
            }

        }

        private void PrintFinalResult()
        {
            int totalFood = repository.Sum(buyer => buyer.Food);
            Console.WriteLine(totalFood);
        }

        private IBuyer BuyFood(string buyer,List<IBuyer> repository)
        {
            IBuyer currBuyer = repository.FirstOrDefault(x => x.Name == buyer);
            return currBuyer;
        }
    }
}
