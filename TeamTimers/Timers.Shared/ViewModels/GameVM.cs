using System;
using System.Collections.Generic;
using System.Text;

namespace Timers.Shared.ViewModels
{
    public class GameVM
    {
        public int GameId { get; set; }
        public int GameSettingId { get; set; }
        public int HomeTeamId { get; set; }
        public int VisitorTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public int VisitorTeamScore { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public GameSettingVM GameSetting { get; set; }
        public TeamVM HomeTeam { get; set; }
        public int SecondsElapsed { get; set; }
        public TeamVM VisitorTeam { get; set; }
    }
}
