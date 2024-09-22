using API.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace API.Roles.Managers
{
	public class RoleManager
	{
		public static void SetRole<T>(Player player) where T : Role
		{
			player.SetRole<T>();
			if (player.identity.isLocalPlayer)
			{
				player.role.LocalInit();
			} else 
				player.role.OnlineInit();
		}
	}
}
