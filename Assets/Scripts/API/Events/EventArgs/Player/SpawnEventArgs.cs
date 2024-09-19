using API.Events.Interfaces;

namespace API.Events.EventArgs.Player
{
	public class SpawnEventArgs: IPlayerEvent
	{
		public Roles.FpcPlayerRole player { get; }
		public SpawnEventArgs(Roles.FpcPlayerRole player) 
		{
			this.player = player;
		}

	}
}
