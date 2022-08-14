using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Engine
    {
        private IList<IBirthable> repository;

        public Engine()
        {
            repository = new List<IBirthable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputTokens = input.Split();
                CreateBirthables(inputTokens);
                input = Console.ReadLine();
            }

            string year = Console.ReadLine();
            string[] birthdates = repository.Where(i => i.Birthdate.EndsWith(year)).Select(i => i.Birthdate).ToArray();
            PrintFinalResult(birthdates);
        }

        private void PrintFinalResult(string[] fakeIds)
        {
            foreach (var fakeId in fakeIds)
            {
                Console.WriteLine(fakeId);
            }
        }

        private void CreateBirthables(string[] inputTokens)
        {

            IBirthable birth = null;

            if (inputTokens[0] == "Citizen")
            {
                string name = inputTokens[1];
                int age = int.Parse(inputTokens[2]);
                string id = inputTokens[3];
                string birthdate = inputTokens[4];
                birth = new Citizen(id, name, age,birthdate);
            }
            else if (inputTokens[0] == "Robot")
            {
                string models = inputTokens[1];
                string id = inputTokens[2];
            }
            else if (inputTokens[0] == "Pet")
            {
                string name = inputTokens[1];
                string birthdate = inputTokens[2];
                birth = new Pet(name, birthdate);
            }

            if (birth != null)
            {
                repository.Add(birth);
            }
        }
    }
}
