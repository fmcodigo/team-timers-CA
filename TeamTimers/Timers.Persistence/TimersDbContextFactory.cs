//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Timers.Persistence
//{
//    public class TimersDbContextFactory : IDesignTimeDbContextFactory<TimersDbContext>
//    {
//        public TimersDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<TimersDbContext>();
//            optionsBuilder.UseSqlite("Data Source=timers.db");

//            return new TimersDbContext(optionsBuilder.Options);
//        }
//    }
//}
