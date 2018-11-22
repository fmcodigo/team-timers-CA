using System;
using Timers.Persistence;
using Xunit;

namespace Timers.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public TimersDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = TimersContextFactory.Create();
        }

        public void Dispose()
        {
            TimersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}