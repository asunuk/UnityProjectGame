using Game.Events.Interfaces;

namespace Game.Events.EventArgs.Player
{
	public class MoveEventArgs: IPlayerEvent
	{
		public Roles.Player player { get; }
		public MoveEventArgs(Roles.Player player) 
		{
			this.player = player;
		}

	}
}
