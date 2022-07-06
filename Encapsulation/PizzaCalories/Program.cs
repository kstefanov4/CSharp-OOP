using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = new Pizza(Console.ReadLine().Split(" ")[1]);
                string doughInfo = Console.ReadLine();
                Dough dough = new Dough(doughInfo.Split(" ")[1], doughInfo.Split(" ")[2], int.Parse(doughInfo.Split(" ")[3]));
                pizza.Dough = dough;
                string toppingInfo = Console.ReadLine();

                while (toppingInfo != "END")
                {
                    Topping topping = new Topping(toppingInfo.Split(" ")[1], int.Parse(toppingInfo.Split(" ")[2]));
                    pizza.AddTopping(topping);
                    toppingInfo = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories()} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
