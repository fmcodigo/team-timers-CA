using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Timers.Domain.Entities;
using Timers.Shared.ViewModels;

namespace Timers.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameVM>();
            CreateMap<GameVM, Game>();
            CreateMap<Team, TeamVM>();
            CreateMap<TeamVM, Team>();
            CreateMap<Player, PlayerVM>();
            CreateMap<PlayerVM, Player>();
            CreateMap<GameSetting, GameSettingVM>();
            CreateMap<GameSettingVM, GameSetting>();
        }
    }
}
