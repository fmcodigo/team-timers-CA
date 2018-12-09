using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using Timers.Persistence;
using Xunit;

namespace Timers.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public TimersDbContext Context { get; private set; }
        public IConfigurationProvider ConfigurationProvider;

        public QueryTestFixture()
        {
            Context = TimersContextFactory.Create();

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new Timers.Application.MappingProfile());
            });
            var mapper = config.CreateMapper();
            ConfigurationProvider = mapper.ConfigurationProvider;

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IMapper>(mapper); //(s => config.CreateMapper());
            services.BuildServiceProvider();

        }

        public void Dispose()
        {
            TimersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}