using System;
using Timers.Persistence;

namespace Timers.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly TimersDbContext _context;

        public CommandTestBase()
        {
            _context = TimersContextFactory.Create();
        }

        public void Dispose()
        {
            TimersContextFactory.Destroy(_context);
        }
    }
}