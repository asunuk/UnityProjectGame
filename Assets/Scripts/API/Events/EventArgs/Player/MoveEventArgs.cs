using API.Events.Interfaces;

namespace API.Events.EventArgs.Player
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
