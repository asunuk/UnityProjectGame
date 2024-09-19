using API.GUI;
using API.Roles;
using API.Roles.Interfaces;

namespace Game.GUI.Types
{
	public class PlayerInfo : TextLabel
	{
		public FpcPlayerRole FPC;
		protected void Update()
		{
			Value = 
				$"PlayerSpeed: {FPC.FPC.CurrentSpeed}\nPlayerHealth:{FPC.Health}";
		}
	}
}
