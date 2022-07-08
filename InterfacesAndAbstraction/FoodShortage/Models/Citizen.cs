using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IPerson, IIdentityable, IBirthable, IBuyer
    {
        private int food = 0;
        public Citizen(string name, int age, string iD, string birthDay)
        {
            this.Name = name;
            this.Age = age;
            this.ID = iD;
            this.BirthDate = birthDay;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get ; private set ; }
        public string BirthDate { get ; private set; }

        public int Food { get => food;private set => food = value; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
