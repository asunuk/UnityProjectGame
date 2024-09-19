using API.Entityes;
using API.Events.Interfaces;
using _Player = API.Roles.FpcPlayerRole;

namespace API.Events.EventArgs.Player
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
