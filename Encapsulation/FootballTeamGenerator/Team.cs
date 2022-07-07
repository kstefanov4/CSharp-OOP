using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        

        public Team(string name)
        {
            Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");

                }
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            Player currentPlayer = players.FirstOrDefault(x => x.Name == player);
            if (currentPlayer == null)
            {
                throw new ArgumentException($"Player {player} is not in {Name} team.");
            }
            this.players.Remove(currentPlayer);
        }

        public int GetRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }
            return (int)Math.Round(this.players.Average(x => x.Stats));
        }
        public override string ToString()
        {
            return $"{this.name} - {this.GetRating()}";
        }

    }
}
