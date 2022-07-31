using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentityable, IBirthable
    {
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
    }
}
