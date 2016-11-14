using System.Collections.Generic;

namespace CodeNamesHelper.Models
{
    public class CodeNamesContext
    {
        public CodeNamesContext()
        {
            BlueTeam = new Team { TeamType = TeamType.Blue };
            RedTeam = new Team { TeamType = TeamType.Red };
            Players = new List<Player>();
        }

        public Team BlueTeam { get; set; }
        public Team RedTeam { get; set; }
        public IList<Player> Players { get; set; }

        public Team GetTeamByType(TeamType type)
        {
            return type == TeamType.Blue ? BlueTeam : RedTeam;
        }

        public Team GetOtherTeamByType(TeamType type)
        {
            return type == TeamType.Blue ? RedTeam : BlueTeam;
        }

        public void ResetTeams()
        {
            BlueTeam = new Team { TeamType = TeamType.Blue };
            RedTeam = new Team { TeamType = TeamType.Red };
        }
    }
}