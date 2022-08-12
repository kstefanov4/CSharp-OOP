using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<IVessel> vessels;
        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.vessels = new List<IVessel>();
        }
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("Captain full name cannot be null or empty string.");
                }
                this.fullName = value;
            }
        }

        public int CombatExperience => this.combatExperience;

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Count != 0)
            {
                foreach (var vessel in vessels)
                {
                    sb.AppendLine($"- {vessel.Name}");
                    sb.AppendLine($" *Type: {vessel.GetType().Name}");
                    sb.AppendLine($" *Armor thickness: {vessel.ArmorThickness}");
                    sb.AppendLine($" *Main weapon caliber: {vessel.MainWeaponCaliber}");
                    sb.AppendLine($" *Speed: {vessel.Speed} knots");
                    sb.AppendLine($" *Targets: {(vessel.Targets.Count == 0 ? "None" : string.Join(", ", vessel.Targets))}");

                    bool result = false;
                    if (vessel.GetType().Name == nameof(Battleship))
                    {
                        result = (vessel as Battleship).SonarMode;
                    }
                    else if (vessel.GetType().Name == nameof(Submarine))
                    {
                        result = (vessel as Submarine).SubmergeMode;
                    }

                    sb.AppendLine($" *{(vessel.GetType().Name == nameof(Battleship) ? "Sonar" : "Submerge")} mode: {(result == true ? "ON" : "OFF" )}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
