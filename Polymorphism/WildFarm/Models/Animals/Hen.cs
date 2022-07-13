using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            base.FoodEaten += food.Quantity;
            base.Weight += food.Quantity * WeightMultiplier;
        }

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}
