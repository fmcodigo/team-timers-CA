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
    public class Details
    {
        private readonly IMediator _mediator;

        public Details(IMediator mediator) => _mediator = mediator;

        public Model Data { get; private set; }

        public async Task OnGetAsync(Query query) => Data = await _mediator.Send(query);

        public class Model
        {
            public int TeamId { get; set; }
            public string Name { get; set; }
            public ICollection<Player> Players { get; set; }
            ////[Display(Name = "Department")]
            //public string DepartmentName { get; set; }
        }

        public class MappingProfile : Profile
        {
            public MappingProfile() => CreateMap<Domain.Entities.Team, Model>();
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(m => m.Id).NotNull();
            }
        }

        public class Query : IRequest<Model>
        {
            public int? Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Model>
        {
            private readonly TimersDbContext _db;
            private readonly IConfigurationProvider _configuration;

            public Handler(TimersDbContext db, IConfigurationProvider configuration)
            {
                _db = db;
                _configuration = configuration;
            }

            public Task<Model> Handle(Query message, CancellationToken token) =>
                _db.Teams
                .Where(i => i.TeamId == message.Id)
                .ProjectTo<Model>(_configuration)
                .SingleOrDefaultAsync(token);
        }
    }
}
