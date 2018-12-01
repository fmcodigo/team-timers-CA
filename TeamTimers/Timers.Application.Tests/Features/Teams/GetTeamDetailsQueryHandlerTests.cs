using AutoMapper;
using Shouldly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timers.Application.Teams;
using Timers.Application.Tests.Infrastructure;
using Timers.Persistence;
using Xunit;

namespace Timers.Application.Tests.Features.Teams
{
    [Collection("QueryCollection")]
    public class GetTeamDetailsQueryHandlerTests
    {
        private readonly TimersDbContext _context;
        private readonly IConfigurationProvider _configurationProvider;

        public GetTeamDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _configurationProvider = fixture.ConfigurationProvider;
        }

        [Fact]
        public async Task GetTeamDetailsTest()
        {
            var sut = new GetTeamDetailsQueryHandler(_context, _configurationProvider);

            var result = await sut.Handle(new GetTeamDetailsQuery { Id=1 }, CancellationToken.None);

            result.ShouldBeOfType<GetTeamDetailModel>();
            result.TeamId.ShouldBe(1);
            result.Name.ShouldBe("Real Madrid");
        }
    }
}
