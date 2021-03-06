﻿using AutoMapper;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timers.Persistence;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Timers.Domain.Entities;
using Timers.Shared.ViewModels;

namespace Timers.Application.Teams
{
    public class GetTeamDetailsQuery : IRequest<TeamVM>
    {
        public int? Id { get; set; }
    }

    public class GetTeamDetailsQueryHandler : IRequestHandler<GetTeamDetailsQuery, TeamVM>
    {
        private readonly TimersDbContext _context;
        private readonly IConfigurationProvider _configuration;

        public GetTeamDetailsQueryHandler(TimersDbContext context, IConfigurationProvider configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<TeamVM> Handle(GetTeamDetailsQuery message, CancellationToken token)
        {
            var result = await _context.Teams
            .Where(i => i.TeamId == message.Id)
            .ProjectTo<TeamVM>(_configuration)
            .SingleOrDefaultAsync(token);

            return result;
        }
    }


    //public class Validator : AbstractValidator<Query>
    //{
    //    public Validator()
    //    {
    //        RuleFor(m => m.Id).NotNull();
    //    }
    //}

}
