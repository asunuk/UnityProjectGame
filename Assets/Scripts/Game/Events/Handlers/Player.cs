using Game.Events.Featchures;
using Game.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Events.Handlers
{
	public class Player
	{
		public static Event<MoveEventArgs> Move { get; set; } = new();
		public static Event<JumpingEventArgs> Jumping { get; set; } = new();
		public static Event<DiedEventArgs> Died { get; set; } = new();
		public static void OnMove(MoveEventArgs ev) => Move.InvokeSafely(ev);
		public static void OnJumping (JumpingEventArgs ev) => Jumping.InvokeSafely(ev);
		public static void OnDied(DiedEventArgs ev) => Died.InvokeSafely(ev);
	}
}
