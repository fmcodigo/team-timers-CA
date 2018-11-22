using System;
using System.Collections.Generic;

namespace Timers.Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
