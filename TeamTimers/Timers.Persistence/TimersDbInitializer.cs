using System;
using System.Collections.Generic;
using System.Text;
using Timers.Domain.Entities;

namespace Timers.Persistence
{
    public class TimersDbInitializer
    {
        public static void SeedDatabase(TimersDbContext context)
        {
            context.Database.EnsureCreated();

            context.Teams.AddRange(new[] {
                new Team { Name ="Real Madrid",
                Players = new[]
                {
                new Player{ Name="James", Jersey="7"},
                new Player{ Name="Pavon", Jersey="7"},
                new Player{ Name="Medel", Jersey="7"},
                new Player{  Name="Figueroa", Jersey="7"},
                new Player{  Name="Cuadrado", Jersey="7"},
                new Player{  Name="Ronaldo", Jersey="7"}
                }
                },

                new Team { Name = "Barcelona",
                Players = new[]
                {
                    new Player{  Name="Messi", Jersey="10"},
                    new Player{  Name="Suarez", Jersey="9"},
                    new Player{  Name="Pele", Jersey="10"},
                    new Player{  Name="Vidal", Jersey="4"},
                    new Player{  Name="Reinoso", Jersey="8"},
                    new Player{  Name="Sanchez", Jersey="7"}
                }
                }
            });

            context.SaveChanges();
        }
    }
}
