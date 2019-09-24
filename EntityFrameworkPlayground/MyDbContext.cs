using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EntityFrameworkPlayground
{
	public class MyDbContext : DbContext
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<Player> Players { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EntityFrameworkPlayground;Trusted_Connection=True;")
				.EnableSensitiveDataLogging()
				.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
		}

		public void SeedTestData()
		{
			Games.Add(new Game
			{
				Name = "First Game",
				Players = new List<Player>
				{
					new Player
					{
						IsWinner = true,
						Name = "Matthias"
					},
					new Player
					{
						IsWinner = false,
						Name = "Lukas"
					}
				}
			});

			Games.Add(new Game {Name = "Second Game"});
			Games.Add(new Game {Name = "Third Game"});
			Games.Add(new Game {Name = "Fourth Game"});

			SaveChanges();
		}
	}
}