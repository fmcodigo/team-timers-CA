using System;
using System.Collections.Generic;
using System.Text;

namespace Timers.Shared.ViewModels
{
    public class PlayerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Jersey { get; set; }
        public int TeamId { get; set; }

        public bool IsPlaying { get; set; }
        public bool IsPresent { get; set; }
        public int SecondsPlayed { get; set; }
    }
}
