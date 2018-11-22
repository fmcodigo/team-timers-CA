using Microsoft.EntityFrameworkCore;
using System;
using Timers.Persistence;

namespace Timers.Application.Tests
{
    public class TestBase
    {
        public TimersDbContext GetDbContext(bool useSqlLite = false)
        {
            var builder = new DbContextOptionsBuilder<TimersDbContext>();
            if (useSqlLite)
            {
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            var dbContext = new TimersDbContext(builder.Options);
            if (useSqlLite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database.
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
