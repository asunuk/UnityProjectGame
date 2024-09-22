using API.Items;
using UnityEngine;
using Mirror;

using API.Managers.Items;


namespace API.Roles.Components
{
	public class NetworkInventory: NetworkBehaviour
	{

		[Header("Основные параметры Inventory")]

		[SerializeField]
		protected SyncList<Item> _slots = new();

		[SyncVar]
		[SerializeField]
		protected PlayerMovableRole _playerRole;

		[SyncVar]
		[SerializeField]
		protected ushort _currentIndex = 0;

		[SyncVar]
		[SerializeField]
		protected ushort _size;

		[SyncVar]
		[SerializeField]
		protected float _dropItemImpulse;

		[SyncVar]
		[SerializeField]
		protected float _maxTakeItemDistance;

		[SyncVar]
		protected Ray _ray;

		public SyncList<Item> slots => _slots;
		public Item itemInHand => slots[currentIndex];
		public ushort currentIndex => _currentIndex;
		public ushort size => _size;
		public float dropItemImpulse => _dropItemImpulse;
		public float maxTakeItemDistance => _maxTakeItemDistance;
		public Ray ray => _ray;

		//Privates
		protected PlayerMovableRole player;

		//Publics

		protected virtual void Start()
		{
			player = GetComponent<PlayerMovableRole>();
		}

		protected virtual void Update()
		{
		}

		#region Server

		[Server]
		protected void SetItemInHand(Item newItem)
		{
			slots[currentIndex] = newItem;
		}

		[Server]
		protected void SetCurrentIndex(ushort newIndex)
		{
			_currentIndex = newIndex;
		}

		[Server] 
		protected void SetRayTranforms(Vector3 origin, Vector3 direction)
		{
			_ray.origin = origin;
			_ray.direction = direction;
		}

		#endregion

		#region Commands

		[Command]
		protected void CmdTake()
		{
			if (itemLookedAt())
			{
				if (itemInHand) CmdDrop();
				SetItemInHand(itemLookedAt());
				ItemManager.DestroyItem(itemLookedAt());
			}
		}

		[Command]
		protected virtual void CmdDrop()
		{
			if (itemInHand)
			{
				SetItemInHand(null);
				Item item = ItemManager.SpawnItem(itemInHand);
				item.rigidBody.AddForce(ray.direction * dropItemImpulse, ForceMode.Impulse);
			}
		}

		[Command]
		public virtual void CmdForwardSlot()
		{
			SetCurrentIndex((ushort)(currentIndex + 1 >= size ? currentIndex : currentIndex + 1));
		}

		[Command]
		public virtual void CmdBackSlot()
		{
			SetCurrentIndex((ushort)(currentIndex - 1 < 0 ? currentIndex : currentIndex - 1));
		}

		#endregion

		public Item getItemByIndex(int index)
		{
			return _slots[index >= size ? size - 1 : index < 0 ? 0 : index];
		}

		public virtual Item itemLookedAt()
		{
			RaycastHit _hit;
			Item item = null;
			if (Physics.Raycast(ray, out _hit))
			{
				item = _hit.collider.gameObject.GetComponent<Item>();
				if (item is not null) item = Vector3.Distance(player.Head.transform.position, item.gameObject.transform.position) <= maxTakeItemDistance ? item : null;
			}
			Debug.Log(item);
			return item;
		}
	}
}
