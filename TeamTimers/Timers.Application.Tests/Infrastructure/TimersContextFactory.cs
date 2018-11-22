using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Timers.Domain.Entities;
using Timers.Persistence;

namespace Timers.Application.Tests.Infrastructure
{
    public class TimersContextFactory
    {
        public static TimersDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TimersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new TimersDbContext(options);

            context.Database.EnsureCreated();

            context.Teams.AddRange(new[] {
                new Domain.Entities.Team { TeamId = 1, Name ="Real Madrid" },
                new Domain.Entities.Team { TeamId = 2, Name = "Barcelona" }
            });

            context.Players.AddRange(new[] {
                new Player{ PlayerId=7, Name="James", Jersey="7", TeamId=1},
                new Player{ PlayerId=8, Name="Pavon", Jersey="7", TeamId=1},
                new Player{ PlayerId=9, Name="Medel", Jersey="7", TeamId=1},
                new Player{ PlayerId=10, Name="Figueroa", Jersey="7", TeamId=1},
                new Player{ PlayerId=11, Name="Cuadrado", Jersey="7", TeamId=1},
                new Player{ PlayerId=12, Name="Ronaldo", Jersey="7", TeamId=1},

                new Player{ PlayerId=1, Name="Messi", Jersey="10", TeamId=2},
                new Player{ PlayerId=2, Name="Suarez", Jersey="9", TeamId=2},
                new Player{ PlayerId=3, Name="Pele", Jersey="10", TeamId=2},
                new Player{ PlayerId=4, Name="Vidal", Jersey="4", TeamId=2},
                new Player{ PlayerId=5, Name="Reinoso", Jersey="8", TeamId=2},
                new Player{ PlayerId=6, Name="Sanchez", Jersey="7", TeamId=2}

            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(TimersDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}