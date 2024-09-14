using Game.Events.Interfaces;

namespace Game.Events.EventArgs.Player
{
	public class MoveEventArgs: IPlayerEvent
	{
		public Roles.FpcPlayerRole player { get; }
		public MoveEventArgs(Roles.FpcPlayerRole player) 
		{
			this.player = player;
		}

	}
}
