using System;
using System.Linq;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        private static object hero;

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while(heroes.Count != num)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    BaseHero druid = new Druid(name);
                    heroes.Add(druid);
                }
                else if (type == "Paladin")
                {
                    BaseHero paladin = new Paladin(name);
                    heroes.Add(paladin);
                }
                else if (type == "Rogue")
                {
                    BaseHero rogue = new Rogue(name);
                    heroes.Add(rogue);
                }
                else if (type == "Warrior")
                {
                    BaseHero warrior = new Warrior(name);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            long bossPower = long.Parse(Console.ReadLine());

            long heroesTotalPower = heroes.Sum(x => x.Power);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                
            }

            if (heroesTotalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
