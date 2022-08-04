using SpaceStation.Core.Contracts;
using SpaceStation.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astronauts.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName, items);
            planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            ICollection<IAstronaut> suitableAstronauts = astronauts.Models.Where(x => x.Oxygen > 60).ToList();

            if (!suitableAstronauts.Any())
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }

            IPlanet planet = planets.FindByName(planetName);
            IMission mission = new Mission();
            mission.Explore(planet, suitableAstronauts);
            exploredPlanets++;
           // int deadAstronauts = suitableAstronauts.Where(x => x.Oxygen == 0).Count();
            return $"Planet: {planetName} was explored! Exploration finished with {suitableAstronauts.Where(x => x.Oxygen == 0).Count()} dead astronauts!";
        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
