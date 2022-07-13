using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                base.FoodEaten += food.Quantity;
                base.Weight += food.Quantity * WeightMultiplier;
            }
            else
            {
                throw new ArgumentException ($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }

    }
}
