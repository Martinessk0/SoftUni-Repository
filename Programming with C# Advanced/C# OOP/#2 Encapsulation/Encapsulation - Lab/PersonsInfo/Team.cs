using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    class Team
    {
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public string Name { get; set; }
        public IReadOnlyList<Person> FirstTeam { get => firstTeam.AsReadOnly(); }
        public IReadOnlyList<Person> ReserveTeam { get => reserveTeam.AsReadOnly(); }

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }

        }

    }
}
