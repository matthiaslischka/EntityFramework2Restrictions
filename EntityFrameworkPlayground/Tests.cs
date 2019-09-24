using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;

namespace EntityFrameworkPlayground
{
	[TestFixture]
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			_currentDbTransaction = _dbContext.Database.BeginTransaction();
		}

		[TearDown]
		public void TearDown()
		{
			_currentDbTransaction.Dispose();
		}

		private IDbContextTransaction _currentDbTransaction;
		private MyDbContext _dbContext;

		[OneTimeSetUp]
		public void SetupFixture()
		{
			_dbContext = new MyDbContext();
			_dbContext.Database.EnsureCreated();
			if (!_dbContext.Games.Any())
				_dbContext.SeedTestData();
		}

		[Test]
		public void Concat()
		{
			var games = _dbContext.Games.Concat(_dbContext.Games).ToList();
		}

		[Test]
		public void First()
		{
			var game = _dbContext.Games.First(x => x.Id == 1);
		}

		[Test]
		public void FirstOrDefault()
		{
			var game = _dbContext.Games.FirstOrDefault(x => x.Id == 1);
		}

		[Test]
		public void NestedConcat()
		{
			var players = _dbContext.Games.Select(x => x.Players.Where(y => y.IsWinner)
					.Concat(x.Players.Where(y => !y.IsWinner)))
				.ToList();
		}

		[Test]
		public void NestedFirst()
		{
			var players = _dbContext.Games.Select(x => x.Players.First()).ToList();
		}

		[Test]
		public void NestedFirstOrDefault()
		{
			var players = _dbContext.Games.Select(x => x.Players.FirstOrDefault()).ToList();
		}

		[Test]
		public void NestedSingle()
		{
			var players = _dbContext.Games.Select(x => x.Players.SingleOrDefault()).ToList();
		}

		[Test]
		public void NestedSingleOrDefault()
		{
			var players = _dbContext.Games.Select(x => x.Players.SingleOrDefault()).ToList();
		}

		[Test]
		public void Single()
		{
			var game = _dbContext.Games.Single(x => x.Id == 1);
		}

		[Test]
		public void SingleOrDefault()
		{
			var game = _dbContext.Games.SingleOrDefault(x => x.Id == 1);
		}
	}
}