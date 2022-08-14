using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    class Hero
    {
        private string username;
        private int level;

        public string Username { get; set; }
        public int Level { get; set; }

        public Hero(string name, int level)
        {
            Username = name;
            Level = level;
        }

        public override string ToString()
            => $"Type: {this.GetType().Name} Username: {Username} Level: {Level}";

    }
}
