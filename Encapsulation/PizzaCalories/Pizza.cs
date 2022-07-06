using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();

        }
        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            {
                if (value == string.Empty || value.Length > 15 || value.Length < 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        public IReadOnlyCollection<Topping> Toppings 
        {
            get => toppings;
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count + 1 > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public Dough Dough 
        { 
            get => this.dough; 
            set => this.dough = value; 
        }

        public decimal TotalCalories()
        {
            decimal totalCalories = dough.GetTotalCalories();

            foreach (var topping in Toppings)
            {
                totalCalories += topping.GetTotalCalories();
            }

            return totalCalories;
        }
    }
}
