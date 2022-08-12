using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Contains(captain))
            {
                return $"Captain {fullName} is already hired.";
            }

            captains.Add(captain);
            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel;
            if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return $"Invalid vessel type.";
            }

            if (vessels.Models.Any(x => x.Name == name))
            {
                return $"{vessel.GetType().Name} vessel {name} is already manufactured.";
            }

            vessels.Add(vessel);
            return $"{vessel.GetType().Name} {name} is manufactured with the main weapon caliber of {vessel.MainWeaponCaliber} inches and a maximum speed of {vessel.Speed} knots.";
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            vessel.Captain = captain;
            captain.AddVessel(vessel);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel.GetType().Name == nameof(Battleship))
            {
                (vessel as Battleship).ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }

            if (vessel.GetType().Name == nameof(Submarine))
            {
                (vessel as Submarine).ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }

            return $"Vessel {vesselName} could not be found.";
        }
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            if (defendingVessel == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attackingVessel.Attack(defendingVessel);
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";
        }



    }
}
