using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{

    public abstract class Gym : IGym
    {
        private string name;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.Equipment.Select(x => x.Weight).Sum();

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");

            string gymAthlets;
            if (Athletes.Count > 0)
            {
                gymAthlets = string.Join(", ", Athletes.Select(x => x.FullName));
            }
            else
            {
                gymAthlets = "No athletes";
            }
            sb.AppendLine($"Athletes: {gymAthlets}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
