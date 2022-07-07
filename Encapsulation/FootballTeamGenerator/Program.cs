using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string command = input.Split(';', StringSplitOptions.RemoveEmptyEntries)[0];
                string teamName = input.Split(';', StringSplitOptions.RemoveEmptyEntries)[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            {
                                Team team = new Team(teamName);
                                teams.Add(teamName, team);
                            }
                            break;
                        case "Add":
                            {
                                if (!teams.ContainsKey(teamName))
                                {
                                    throw new ArgumentException($"Team {teamName} does not exist.");
                                }

                                string playerName = input.Split(';', StringSplitOptions.RemoveEmptyEntries)[2];
                                int endurance = int.Parse(input.Split(';', StringSplitOptions.RemoveEmptyEntries)[3]);
                                int sprint = int.Parse(input.Split(';', StringSplitOptions.RemoveEmptyEntries)[4]);
                                int dribble = int.Parse(input.Split(';', StringSplitOptions.RemoveEmptyEntries)[5]);
                                int passing = int.Parse(input.Split(';', StringSplitOptions.RemoveEmptyEntries)[6]);
                                int shooting = int.Parse(input.Split(';', StringSplitOptions.RemoveEmptyEntries)[7]);

                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                teams[teamName].AddPlayer(player);
                            }
                            break;
                        case "Remove":
                            {
                                string playerToRemove = input.Split(';', StringSplitOptions.RemoveEmptyEntries)[2];
                                teams[teamName].RemovePlayer(playerToRemove);
                            }

                            break;
                        case "Rating":
                            {
                                if (!teams.ContainsKey(teamName))
                                {
                                    throw new ArgumentException($"Team {teamName} does not exist.");
                                }
                                Console.WriteLine(teams[teamName]);
                            }
                            break;

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
