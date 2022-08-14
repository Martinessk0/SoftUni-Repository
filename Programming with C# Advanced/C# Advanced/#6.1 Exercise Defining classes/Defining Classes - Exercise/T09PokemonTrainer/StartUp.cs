using System;
using System.Collections.Generic;
using System.Linq;

namespace T09PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();
            while (input != "Tournament")
            {
                string[] data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = data[0];
                string pokemonName = data[1];
                string element = data[2];
                int health = int.Parse(data[3]);
                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer trainer = trainers.First(t => t.Name == trainerName);

                trainer.AddPokemon(new Pokemon(pokemonName,element, health));
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.IncreaseBadges();
                    }
                    else
                    {
                        trainer.ReducePokemonsHealts();
                        trainer.RemoveDead();
                    }
                }

                input = Console.ReadLine();
            }
            trainers
                .OrderByDescending(t => t.NumberOfBadges)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
