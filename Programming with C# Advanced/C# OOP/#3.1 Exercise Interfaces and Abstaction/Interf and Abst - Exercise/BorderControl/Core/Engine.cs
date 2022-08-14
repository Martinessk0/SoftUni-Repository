using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using BorderControl.Contracts;

namespace BorderControl
{
    public class Engine
    {
        private List<IIdentifable> repository;

        public Engine()
        {
            repository = new List<IIdentifable>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputTokens = input.Split();
                CreateIdentifiable(inputTokens);
                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();
            string[] fakeIds = repository.Where(i => i.Id.EndsWith(fakeId)).Select(i => i.Id).ToArray();
            PrintFinalResult(fakeIds);
        }

        private void PrintFinalResult(string[] fakeIds)
        {
            foreach (var fakeId in fakeIds)
            {
                Console.WriteLine(fakeId);
            }
        }

        private void CreateIdentifiable(string[] inputTokens)
        {
            IIdentifable identifable;
            if (inputTokens.Length == 3)
            {
                string name = inputTokens[0];
                int age = int.Parse(inputTokens[1]);
                string id = inputTokens[2];
                identifable = new Citizen(id, name, age);
            }
            else
            {
                string models = inputTokens[0];
                string id = inputTokens[1];
                identifable = new Robot(id, models);
            }
            repository.Add(identifable);
        }
    }
}
