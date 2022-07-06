using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dough dough = new Dough("White", "Chewy", 100);
            Console.WriteLine(dough.BakingTechniques);
            Console.WriteLine(dough.FlourType);
            Console.WriteLine(dough.Weight);
            Console.WriteLine(dough.GetTotalCalories());

            Topping topping = new Topping("Krenvirshi", 30);
            Console.WriteLine(topping.GetTotalCalories());
        }
    }
}
