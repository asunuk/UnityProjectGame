using Game.Events.Interfaces;
using _Player = Game.Roles.FpcPlayerRole;

namespace Game.Events.EventArgs.Player
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
