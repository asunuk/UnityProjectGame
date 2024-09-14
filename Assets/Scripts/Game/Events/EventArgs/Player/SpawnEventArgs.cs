using Game.Events.Interfaces;

namespace Game.Events.EventArgs.Player
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
