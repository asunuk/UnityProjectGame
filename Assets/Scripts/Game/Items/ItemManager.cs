using Game.Items.Types;
using UnityEngine;

namespace Game.Items
{
	public class ItemManager : MonoBehaviour
	{
		public static BaseItem SpawnItem<T>(Vector3 position) where T : ItemBaseType, new()
		{
			T t = new();
			BaseItem item = Instantiate(t.visual.gameObject).AddComponent<BaseItem>();
			item.gameObject.transform.position = position;
			item.itemType = t;
			t.item = item;
			Debug.Log("Spawned tool, with type :" + item.itemType);
			return item;
		}

		

		public static void DestroyItem(BaseItem item)
		{
			Destroy(item.gameObject);
		}
	}
}
