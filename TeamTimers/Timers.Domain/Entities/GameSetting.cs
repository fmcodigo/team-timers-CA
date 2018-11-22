using System;
using System.Collections.Generic;

namespace Timers.Domain.Entities
{
    public class GameSetting
    {
        public GameSetting()
        {
            Games = new HashSet<Game>();
        }

        public int GameSettingId { get; set; }
        public string Name { get; set; }
        public int MaxPlayersAllowed { get; set; }
        public int Periods { get; set; }
        public int MinutesPerPeriod { get; set; }
        public bool IsCountdown { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
