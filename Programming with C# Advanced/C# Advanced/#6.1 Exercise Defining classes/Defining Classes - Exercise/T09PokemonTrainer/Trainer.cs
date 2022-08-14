using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T09PokemonTrainer
{
    class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }

        public void RemoveDead()
        {
            Pokemons = Pokemons.Where(p => p.Health > 0).ToList();
        }

        public void ReducePokemonsHealts()
        {
            Pokemons.ForEach(p => p.ReduceHealth());
        }
        public void IncreaseBadges()
        {
            NumberOfBadges++;
        }

        public override string ToString()
        {
            return $"{Name} {NumberOfBadges} {Pokemons.Count}";
        }
    }
}
