using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const string InvalidTypeException = "Invalid type of dough.";
        private const string InvalidWeightException = "Invalid type of dough.";

        internal Dictionary<string, decimal> flourTypeModifiers = new Dictionary<string, decimal>
        {
            { "white",1.5m},
            { "wholegrain",1.0m}
        };
        internal Dictionary<string, decimal> bakingTechniqueModifiers = new Dictionary<string, decimal>
        {
            { "crispy",0.9m},
            { "chewy",1.1m},
            { "homemade",1.0m}
        };
        private string flourType;
        private string bakingTechniques;
        private int weight;

        public Dough(string flourType, string bakingTechniques, int weight)
        {
            FlourType = flourType;
            BakingTechniques = bakingTechniques;
            Weight = weight;
        }

        public string FlourType
        {
            get 
            { 
                return flourType; 
            }
            set 
            {
                if (!flourTypeModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(InvalidTypeException);
                }
                flourType = value; 
            }
        }

        public string BakingTechniques
        {
            get 
            { 
                return bakingTechniques; 
            }
            set 
            {
                if (!bakingTechniqueModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(InvalidTypeException);
                }
                bakingTechniques = value; 
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentOutOfRangeException(InvalidWeightException);
                }
                weight = value; 
            }
        }

        public decimal GetTotalCalories()
        {
            decimal calories = 2 * Weight * flourTypeModifiers[flourType.ToLower()] * bakingTechniqueModifiers[BakingTechniques.ToLower()];
            return calories ;
        }

    }
}
