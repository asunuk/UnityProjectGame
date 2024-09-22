using API.Events.Interfaces;

namespace API.Events.EventArgs.Player
{
	public class SpawnEventArgs: IPlayerEvent
	{
		public Roles.PlayerMovableRole player { get; }
		public SpawnEventArgs(Roles.PlayerMovableRole player) 
		{
			this.player = player;
		}

	}
}
