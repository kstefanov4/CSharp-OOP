using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {

        internal Dictionary<string, decimal> topingModifiers = new Dictionary<string, decimal>
        {
            { "Meat",1.2m},
            { "Veggies",0.8m},
            { "Cheese",1.1m},
            { "Sauce",0.9m},
        };

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            get 
            { 
                return toppingType; 
            }
            set 
            {
                if (!topingModifiers.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentOutOfRangeException($"{value} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public decimal GetTotalCalories()
        {
            return 2 * Weight * topingModifiers[toppingType];
        }

    }
}
