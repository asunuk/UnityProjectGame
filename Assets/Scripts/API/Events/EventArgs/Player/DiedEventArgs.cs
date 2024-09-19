using API.Events.Interfaces;
using _Player = API.Roles.FpcPlayerRole;

namespace API.Events.EventArgs.Player
{
	public class DiedEventArgs : IPlayerEvent
	{
		public _Player player { get; }
		public DiedEventArgs(_Player player)
		{
			this.player = player;
		}

		public object dieadReason => player.FPC.isJumping;
	}
}
