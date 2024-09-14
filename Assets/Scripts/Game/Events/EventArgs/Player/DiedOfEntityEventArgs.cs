using Game.Entityes;
using Game.Events.Interfaces;
using _Player = Game.Roles.FpcPlayerRole;

namespace Game.Events.EventArgs.Player
{
	public class DiedOfEntityEventArgs : IPlayerEvent
	{
		public _Player player { get; }
		public DiedOfEntityEventArgs(_Player player)
		{
			this.player = player;
		}

		public Entity killer { get; set; }
		public object dieadReason => player.FPC.isJumping;
	}
}
