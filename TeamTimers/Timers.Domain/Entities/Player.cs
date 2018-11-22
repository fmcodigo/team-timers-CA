using System;

namespace Timers.Domain.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Jersey { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
