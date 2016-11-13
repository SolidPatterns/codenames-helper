using System.Collections.Generic;

namespace CodeNamesHelper.Models
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
        }

        public IList<Player> Players { get; set; }
        public TeamType TeamType { get; set; }
    }
}