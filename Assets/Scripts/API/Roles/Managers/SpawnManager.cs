using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Roles.Managers
{
	public class SpawnManager
	{
		public static void Spawn(string username, Role role)
		{
			
		}

		public static void Spawn(Player player, Role role) 
		{
			player.SetRole(role);
		}
	}
}
