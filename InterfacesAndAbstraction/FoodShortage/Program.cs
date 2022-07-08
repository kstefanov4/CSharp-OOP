using System;
using System.Collections.Generic;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    IBuyer citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);

                    buyers.Add(input[0], citizen);

                }
                else
                {
                    IBuyer rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);

                    buyers.Add(input[0], rebel);

                }

            }

            string nameWhoBuys = Console.ReadLine();

            while (nameWhoBuys != "End")
            {
                if (buyers.ContainsKey(nameWhoBuys))
                {
                    buyers[nameWhoBuys].BuyFood();
                }

                nameWhoBuys = Console.ReadLine();
            }

            int totalFoodAmount = 0;

            foreach (var buyer in buyers)
            {
                totalFoodAmount += buyer.Value.Food;
            }

            Console.WriteLine(totalFoodAmount);
        }
    }
}
