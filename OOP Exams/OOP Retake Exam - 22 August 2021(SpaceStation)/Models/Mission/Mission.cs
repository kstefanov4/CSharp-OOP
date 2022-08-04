using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.CanBreath)
                {
                    while (planet.Items.Any())
                    {
                        string element = planet.Items.ElementAt(0);
                        astronaut.Bag.Items.Add(element);
                        astronaut.Breath();
                        planet.Items.Remove(element);
                        if (astronaut.Oxygen == 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
