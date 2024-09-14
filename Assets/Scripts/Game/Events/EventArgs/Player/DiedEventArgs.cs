using Game.Events.Interfaces;
using _Player = Game.Roles.FpcPlayerRole;

namespace Game.Events.EventArgs.Player
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
