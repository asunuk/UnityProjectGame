using API.GUI;
using API.Roles;
using API.Roles.Interfaces;

namespace Game.EGUI.Types
{
	public class PlayerInfo : TextLabel
	{
		public PlayerMovableRole FPC;
		protected void Update()
		{
			Value = 
				$"PlayerSpeed: {FPC.Movement.CurrentSpeed}\nPlayerHealth:{FPC.Health}";
		}
	}
}
