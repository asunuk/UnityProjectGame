using API.Events.Interfaces;
using _Player = API.Roles.FpcPlayerRole;

namespace API.Events.EventArgs.Player
{
	public class JumpingEventArgs : IPlayerEvent
	{
		public _Player player { get; }
		public JumpingEventArgs(_Player player)
		{
			this.player = player;
		}

		public bool isJumping => player.FPC.isJumping;
	}
}
