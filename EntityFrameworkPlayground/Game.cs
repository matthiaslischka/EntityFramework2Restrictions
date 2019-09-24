using System.Collections.Generic;

namespace EntityFrameworkPlayground
{
	public class Game : Entity
	{
		public string Name { get; set; }
		public ICollection<Player> Players { get; set; }
	}
}