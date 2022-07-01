using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> secondTeam;

        public Team(string name)
        {
            Name = name;
            this.firstTeam = new List<Person>();
            this.secondTeam = new List<Person>();
        }

        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            { 
                name = value; 
            }
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return this.firstTeam;
            }
            
        }
        public IReadOnlyCollection<Person> SecondTeam
        {
            get
            {
                return this.secondTeam;
            }
            
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                secondTeam.Add(person);
            }
        }

    }
}
