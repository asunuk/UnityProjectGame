using API.Items.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace API.Items
{
	[RequireComponent(typeof(Rigidbody))]
	public class BaseItem : MonoBehaviour
	{
		public ItemBaseType itemType;
	}

	[Serializable]
	public class ItemData
	{
		public readonly ItemBaseType itemType;
		public readonly System.Numerics.Vector3 position, rotation;

		public ItemData(ItemBaseType itemType, BaseItem item)
		{
			this.itemType = itemType;
			Vector3 posv = item.gameObject.transform.position;
			Vector3 angelrotv = item.gameObject.transform.rotation.eulerAngles;
			position = new System.Numerics.Vector3(posv.x, posv.y, posv.z);
			rotation = new System.Numerics.Vector3(angelrotv.x, angelrotv.y, angelrotv.z);
		}
	}
}
