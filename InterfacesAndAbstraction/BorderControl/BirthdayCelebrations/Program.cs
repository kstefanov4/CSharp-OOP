using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IBirthable> birthableList = new List<IBirthable>();
            while (input != "End")
            {
                string[] infoArray = input.Split();

                switch (infoArray[0])
                {
                    case "Citizen":
                        IBirthable citizen = new Citizen(infoArray[1], int.Parse(infoArray[2]), infoArray[3], infoArray[4]);
                        birthableList.Add(citizen);
                        break;
                    case "Pet":
                        IBirthable pet = new Pet(infoArray[1], infoArray[2]);
                        birthableList.Add(pet);
                        break;
                    default:
                        input = Console.ReadLine();
                        continue;
                }

                input = Console.ReadLine();
            }
            string specificYear = Console.ReadLine();
            var filteredByYear = birthableList.Where(x => x.BirthDate.EndsWith(specificYear)).ToList();

            foreach (var item in filteredByYear)
            {
                Console.WriteLine(item.BirthDate);
            }
        }
    }
}
