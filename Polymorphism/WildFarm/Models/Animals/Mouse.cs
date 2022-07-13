using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double WeightMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            switch (food.GetType().Name)
            {
                case "Vegetable":
                case "Fruit":
                    base.FoodEaten += food.Quantity;
                    base.Weight += food.Quantity * WeightMultiplier;
                    break;
                default:
                    throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            
        }

        public override string ProduceSound()
        {
            return $"Squeak";
        }
    }
}
