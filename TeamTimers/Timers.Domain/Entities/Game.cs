using System;

namespace Timers.Domain.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public int HomeTeamScore { get; set; }
        public int VisitorTeamScore { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int GameSettingId { get; set; }
        public int HomeTeamId { get; set; }
        public int VisitorTeamId { get; set; }

        public GameSetting GameSetting { get; set; }
        public Team HomeTeam { get; set; }
        public Team VisitorTeam { get; set; }
    }

}
