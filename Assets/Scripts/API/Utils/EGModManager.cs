using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Utils
{
	public class EGModManager : NetworkBehaviour
	{
		protected static List<EGMod> registeredMods = new();
		public static void RegisterMod(EGMod mod)
		{
			if (!registeredMods.Contains(mod)) registeredMods.Add(mod);
		}
		protected void Start()
		{
			registeredMods.ForEach(mod =>
			{
				mod.OnEnable();
			});
		}

		protected void OnDestroy()
		{
			registeredMods.ForEach(mod =>
			{
				mod.OnDisable();
			});
		}
	}

}
