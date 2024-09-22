using API.Events.Interfaces;

namespace API.Events.EventArgs.Player
{
	public class MoveEventArgs: IPlayerEvent
	{
		public Roles.PlayerMovableRole player { get; }
		public MoveEventArgs(Roles.PlayerMovableRole player) 
		{
			this.player = player;
		}

	}
}
