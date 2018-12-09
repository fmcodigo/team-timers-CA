using System;
using System.Collections.Generic;
using System.Text;

namespace Timers.Shared.ViewModels
{
    public class GameSettingVM
    {
        public int GameSettingId { get; set; }
        public string Name { get; set; }
        public int MaxPlayersAllowed { get; set; }
        public int Periods { get; set; }
        public int MinutesPerPeriod { get; set; }
        public bool IsCountdown { get; set; }

        public int MaxPlayerSeconds { get; }
    }
}
