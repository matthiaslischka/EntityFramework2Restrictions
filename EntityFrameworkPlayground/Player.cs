using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkPlayground
{
	public class Player : Entity
	{
		public long GameId { get; set; }

		[ForeignKey(nameof(GameId))]
		public Game Game { get; set; }

		public string Name { get; set; }

		public bool IsWinner { get; set; }
	}
}