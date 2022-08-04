using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipments;
        private ICollection<IGym> gyms;

        public Controller()
        {
            equipments = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            bool isAdded = false;
            if (athleteType == "Boxer")
            {
                if (gym.GetType().Name == nameof(BoxingGym))
                {
                    isAdded = true;
                    Boxer boxer = new Boxer(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(boxer);
                }
            }
            else if (athleteType == "Weightlifter")
            {
                if (gym.GetType().Name == nameof(WeightliftingGym))
                {
                    isAdded = true;
                    Weightlifter weightlifter = new Weightlifter(athleteName, motivation, numberOfMedals);
                    gym.AddAthlete(weightlifter);

                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (isAdded)
            {
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }

            /*Athlete athlete;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == "Boxer" && gymName == "BoxingGym")
            {
                gym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter" && gymName == "WeightliftingGym")
            {
                gym.AddAthlete(athlete);
            }
            else
            {
                return "The gym is not appropriate.";
            }

            return $"Successfully added {athleteType} to {gymName}.";*/
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            this.equipments.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);

        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            IEquipment equipment = this.equipments.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gym.AddEquipment(equipment);
            this.equipments.Remove(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
