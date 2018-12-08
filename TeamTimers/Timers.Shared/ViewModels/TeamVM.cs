﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Timers.Shared.ViewModels
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<PlayerVM> Players { get; set; }
    }
}
