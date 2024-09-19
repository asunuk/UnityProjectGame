//using Items;
using API.Items;
using API.Items.Types;
using API.Roles.Interfaces;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace API.Roles.PlayerComponents
{
	public class Inventory : MonoBehaviour
	{
		public static Inventory Instance;

		[Header("Основные параметры Inventory")]

		//Publics
		public int size = 2;
		public float dropItemImpulse = 1.5f;
		public float maxTakeItemDistance = 10.0f;

		//Getters
		public Ray ray => _ray;
		public int index => _index;
		public BaseItem[] inventorySlots => _inventorySlots ;

		//Privates
		private FpcPlayerRole Player;
		private IFirstPersonController FPC;
		private Ray _ray;
		private int _index = 0;
		public BaseItem[] _inventorySlots;

		[Header("Клавишы для управления инвентарём")]

		//Publics
		public KeyCode
			forwardSlotKey = KeyCode.Alpha2;
		public KeyCode
			backSlotKey = KeyCode.Alpha1,
			takeItemKey = KeyCode.E,
			dropItemKey = KeyCode.Q,
			useItemKey = KeyCode.F;

		public void Start()
		{
			_inventorySlots = new BaseItem[size];

			Player = GetComponent<FpcPlayerRole>();
			FPC = Player.FPC;
		}

		public void Update()
		{
			//itemNameText.text = itemLookedAt() ? itemLookedAt().itemType.Name : null;

			_ray.origin = Player.FPC.Camera.transform.position;
			_ray.direction = Player.FPC.Camera.transform.forward;

			float mw = Input.GetAxis("Mouse ScrollWheel");

			if (Input.GetKeyDown(forwardSlotKey)) ForwardSlot();
			if (Input.GetKeyDown(backSlotKey)) BackSlot();

			ChangeSlotsOnScroll(mw);

			InteractionWithItems();

			//UseItemsLogic(getItemInHand().itemType);

			Debug.Log("Текущий слот: " + getItemInHand());
			Debug.Log("Текущий индекс: " + _index);
		}

		protected void ChangeSlotsOnScroll(float mouseScrollWheelAxis)
		{
			if (mouseScrollWheelAxis > 0.1) ForwardSlot();
			else if (mouseScrollWheelAxis < -0.1) BackSlot();
		}

		protected virtual void UseItemsLogic(ItemBaseType item)
		{
			if (Input.GetKeyDown(useItemKey))
			{
				if (getItemInHand().itemType is ToolType tool) tool.Use();
			}
		}

		protected virtual void InteractionWithItems()
		{
			if (Input.GetKeyDown(takeItemKey))
			{
				if (itemLookedAt() && getItemInHand()) Drop();
				Take();
			}
			else if (Input.GetKeyDown(dropItemKey) && getItemInHand())
			{
				Drop();
			}
		}

		protected void Take()
		{
			if (itemLookedAt())
			{
				if (getItemInHand()) Drop();
				inventorySlots[index] = itemLookedAt();
				inventorySlots[index].gameObject.GetComponent<Renderer>().enabled = false;
				inventorySlots[index].gameObject.GetComponent<Collider>().enabled = false;
				inventorySlots[index].gameObject.GetComponent<Rigidbody>().useGravity = false;
			}
		}

		protected void Drop()
		{
			if (getItemInHand())
			{
				getItemInHand().gameObject.GetComponent<Renderer>().enabled = true;
				getItemInHand().gameObject.GetComponent<Collider>().enabled = true;
				getItemInHand().gameObject.GetComponent<Rigidbody>().useGravity = true;
				getItemInHand().gameObject.transform.position = Player.FPC.Camera.transform.position + ray.direction.normalized;
				getItemInHand().gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * dropItemImpulse, ForceMode.Impulse);
				inventorySlots[index] = null;
			}
		}

		public void ForwardSlot()
		{
			_index = _index + 1 >= _inventorySlots.Length ? _index : _index + 1;
		}

		public void BackSlot()
		{
			_index = _index - 1 < 0 ? _index : _index - 1;
		}

		public BaseItem getItemByIndex(int index)
		{
			return _inventorySlots[index >= _inventorySlots.Length ? _inventorySlots.Length - 1 : index < 0 ? 0 : index];
		}

		public BaseItem getItemInHand()
		{
			return _inventorySlots[_index];
		}

		public BaseItem itemLookedAt()
		{
			RaycastHit _hit;
			BaseItem item = null;
			if (Physics.Raycast(ray, out _hit))
			{
				item = _hit.collider.gameObject.GetComponent<BaseItem>();
				if(item is not null) item = Vector3.Distance(Player.FPC.Camera.transform.position, item.gameObject.transform.position) <= maxTakeItemDistance ? item : null;
			}
			Debug.Log(item);
			return item;
		}
	}

	[Serializable]
	public struct InventoryData
	{
		public readonly int index;
		public readonly ItemData[] itemDatas;

		public InventoryData(int index, ItemData[] itemDatas)
		{
			this.index = index;
			this.itemDatas = itemDatas;
		}

		public InventoryData(Inventory inventory)
		{
			int i = 0;
			index = inventory.index;
			itemDatas = new ItemData[inventory.inventorySlots.Length];
			foreach (BaseItem item in inventory.inventorySlots)
			{
				itemDatas[i] = new ItemData(item.itemType, item);
				i++;
			}
		}

	}
}