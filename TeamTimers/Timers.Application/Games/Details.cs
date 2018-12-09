using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Timers.Persistence;
using Timers.Shared.ViewModels;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Timers.Application.Games
{
    public class DetailsQuery : IRequest<GameVM>
    {
        public int? Id { get; set; }
    }

    public class DetailsQueryHandler : IRequestHandler<DetailsQuery, GameVM>
    {
        private readonly TimersDbContext _context;
        private readonly IConfigurationProvider _configuration;

        public DetailsQueryHandler(TimersDbContext context, IConfigurationProvider configuration)
        {
            _context = context;
            _configuration = configuration;
            //TimersDbInitializer.SeedDatabase(_context);
        }

        public async Task<GameVM> Handle(DetailsQuery message, CancellationToken token)
        {
            var gameVM = await _context.Games
            .Where(g => g.GameId == message.Id)
            .Include(g => g.HomeTeam).ThenInclude(t => t.Players)
            .Include(g => g.VisitorTeam).ThenInclude(t => t.Players)
            .ProjectTo<GameVM>(_configuration)
            .SingleOrDefaultAsync(token);

            return gameVM;
        }
    }


    //public class GameVM
    //{
    //    int Id { get; set; }
    //    int GameSettingId { get; set; }
    //    int HomeTeamId { get; set; }
    //    int VisitorTeamId { get; set; }
    //    int HomeTeamScore { get; set; }
    //    int VisitorTeamScore { get; set; }
    //    DateTime StartTime { get; set; }
    //    DateTime EndTime { get; set; }

    //    GameSettingVM GameSetting { get; set; }
    //    TeamVM HomeTeam { get; set; }
    //    int SecondsElapsed { get; set; }
    //    TeamVM VisitorTeam { get; set; }

    //}

    //public class GameSettingVM
    //{
    //    int Id { get; set; }
    //    string Name { get; set; }
    //    int MaxPlayersAllowed { get; set; }
    //    int Periods { get; set; }
    //    int MinutesPerPeriod { get; set; }
    //    bool IsCountdown { get; set; }

    //    int MaxPlayerSeconds { get; }
    //}

    //public class TeamVM
    //{
    //    int Id { get; set; }
    //    string Name { get; set; }

    //    IEnumerable<PlayerVM> Players { get; set; }
    //}

    //public class PlayerVM
    //{
    //    int Id { get; set; }
    //    string Name { get; set; }
    //    string Jersey { get; set; }
    //    int TeamId { get; set; }

    //    bool IsPlaying { get; set; }
    //    bool IsPresent { get; set; }
    //    int SecondsPlayed { get; set; }
    //}
}
