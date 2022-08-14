using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Engine
    {
        public void Run()
        {
            List<IHero> raid = new List<IHero>();

            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            while (n != counter)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch (type)
                {
                    case "Druid":
                        IHero druid = new Druid(name);
                        raid.Add(druid);
                        counter++;
                        break;
                    case "Paladin":
                        IHero paladin = new Paladin(name);
                        raid.Add(paladin);
                        counter++;
                        break;
                    case "Rogue":
                        IHero rogue = new Rogue(name);
                        raid.Add(rogue);
                        counter++;
                        break;
                    case "Warrior":
                        IHero warrior = new Warrior(name);
                        raid.Add(warrior);
                        counter++;
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            int bossPoints = int.Parse(Console.ReadLine());
            int heroesPoints = 0;
            foreach (var hero in raid)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPoints += hero.Power;
            }

            if (heroesPoints >= bossPoints) Console.WriteLine("Victory!");
            else Console.WriteLine("Defeat...");
        }
    }
}
