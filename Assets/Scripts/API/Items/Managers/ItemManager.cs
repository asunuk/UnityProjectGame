using API.Items;
using API.Items.Types;
using Mirror;
using UnityEngine;

namespace API.Managers.Items
{
	public class ItemManager : MonoBehaviour
	{
		public static Item SpawnItem<T>(Vector3 position) where T : ItemBaseType, new()
		{
			T t = new();
			Item item = Instantiate(t.visual.gameObject).AddComponent<Item>();
			item.gameObject.transform.position = position;
			item.itemType = t;
			t.item = item;
			Debug.Log("Spawned tool, with type :" + item.itemType);
			return item;
		}


		[Server]
		public static void DestroyItem(Item item)
		{
			Destroy(item.gameObject);
			NetworkServer.Destroy(item.gameObject);
		}

		[Server]
		public static Item SpawnItem(Item item)
		{
			Instantiate(item.gameObject).AddComponent<Item>();
			NetworkServer.Spawn(item.gameObject);
			return item;
		}
	}
}
