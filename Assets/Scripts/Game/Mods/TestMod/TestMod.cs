using API.Utils;
using UnityEngine;

namespace Game.Mods.TestMod
{
	public class TestMod : EGMod
	{
		public override void OnEnable()
		{
			base.OnEnable();

			GameObject cub = EGLoader.LoadAndInstatiatePrefab<GameObject>("cub", Vector3.zero, Quaternion.identity);
		}
	}
}
