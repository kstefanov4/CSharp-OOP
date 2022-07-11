using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favoriteFood;

        protected Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }

        public string Name { get => name; set => name = value; }
        public string FavoriteFood { get => favoriteFood; set => favoriteFood = value; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {FavoriteFood}";
        }
    }
}
