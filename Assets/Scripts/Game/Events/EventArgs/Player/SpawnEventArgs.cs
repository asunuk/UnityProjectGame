using Game.Events.Interfaces;

namespace Game.Events.EventArgs.Player
{
	public class SpawnEventArgs: IPlayerEvent
	{
		public Roles.Player player { get; }
		public SpawnEventArgs(Roles.Player player) 
		{
			this.player = player;
		}

	}
}
