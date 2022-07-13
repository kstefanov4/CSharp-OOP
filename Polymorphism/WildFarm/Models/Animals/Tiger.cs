using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double WeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            switch (food.GetType().Name)
            {
                case "Meat":
                    base.FoodEaten += food.Quantity;
                    base.Weight += food.Quantity * WeightMultiplier;
                    break;
                default:
                    throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

        }

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
