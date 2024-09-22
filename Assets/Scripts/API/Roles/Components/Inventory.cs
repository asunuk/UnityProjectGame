using API.Items;
using Mirror;
using System;
using UnityEngine;


namespace API.Roles.Components
{
	public class Inventory : NetworkInventory
	{

		[Header("Клавишы для управления инвентарём")]

		[SerializeField]
		protected KeyCode
			forwardSlotKey = KeyCode.Alpha2;
		[SerializeField]
		protected KeyCode
			backSlotKey = KeyCode.Alpha1,
			takeItemKey = KeyCode.E,
			dropItemKey = KeyCode.Q,
			useItemKey = KeyCode.F;

		protected FPC FPC;
		protected override void Start()
		{
			FPC = GetComponent<FPC>();
		}
		protected override void Update()
		{

			SetRayTranforms(FPC.Camera.transform.position, FPC.Camera.transform.forward);

			if (isOwned)
			{
				float mw = Input.GetAxis("Mouse ScrollWheel");

				if (Input.GetKeyDown(forwardSlotKey)) CmdForwardSlot();
				if (Input.GetKeyDown(backSlotKey)) CmdBackSlot();

				ChangeSlotsOnScroll(mw);
			}

		}

		[Command]
		protected void ChangeSlotsOnScroll(float mouseScrollWheelAxis)
		{
			if (mouseScrollWheelAxis > 0.1) CmdForwardSlot();
			else if (mouseScrollWheelAxis < -0.1) CmdBackSlot();
		}

		public override Item itemLookedAt()
		{
			RaycastHit _hit;
			Item item = null;
			if (Physics.Raycast(ray, out _hit))
			{
				item = _hit.collider.gameObject.GetComponent<Item>();
				if (item is not null) item = Vector3.Distance(FPC.Camera.transform.position, item.gameObject.transform.position) <= maxTakeItemDistance ? item : null;
			}
			Debug.Log(item);
			return item;
		}



	}
}