using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timers.Persistence;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Timers.Domain.Entities;

namespace Timers.Application.Teams
{
    public class GetTeamDetailsQuery : IRequest<GetTeamDetailModel>
    {
        public int? Id { get; set; }
    }

    public class GetTeamDetailsQueryHandler : IRequestHandler<GetTeamDetailsQuery, GetTeamDetailModel>
    {
        private readonly TimersDbContext _context;
        private readonly IConfigurationProvider _configuration;

        public GetTeamDetailsQueryHandler(TimersDbContext context, IConfigurationProvider configuration)
        {
            _context = context;
            _configuration = configuration;
            //TimersDbInitializer.SeedDatabase(_context);
        }

        public async Task<GetTeamDetailModel> Handle(GetTeamDetailsQuery message, CancellationToken token)
        {
            var result = await _context.Teams
            .Where(i => i.TeamId == message.Id)
            .ProjectTo<GetTeamDetailModel>(_configuration)
            .SingleOrDefaultAsync(token);

            return result;
        }
    }

    public class GetTeamDetailModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public ICollection<Player> Players { get; set; }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<Domain.Entities.Team, GetTeamDetailModel>();
    }

    //public class Validator : AbstractValidator<Query>
    //{
    //    public Validator()
    //    {
    //        RuleFor(m => m.Id).NotNull();
    //    }
    //}

}
