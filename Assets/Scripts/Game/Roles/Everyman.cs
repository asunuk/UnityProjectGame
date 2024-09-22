using API.Console;
using API.Locations;
using API.Locations.Interfaces;
using API.Roles;
using API.Roles.Components;
using API.Roles.Exceptions;
using API.Roles.Interfaces;
using API.Roles.Managers;
using API.Roles.PlayerComponents;
using Mirror;
using Mirror.Experimental;
using UnityEngine;

namespace Game.Roles
{

	[RequireComponent(
		typeof(Inventory),
		typeof(Interaction),
		typeof(Rigidbody))
	]

	public class Everyman : PlayerMovableRole
	{
		[Header("Основные компоненты Everyman")]
		[SerializeField]
		protected GameObject _Body;

		[SerializeField]
		protected GameObject _Head;

		[SerializeField]
		protected NetworkInventory _inventory;

		[SerializeField]
		protected Interaction _interaction;

		[SerializeField]
		protected NetworkFPC _netFPC;

		[SerializeField]
		protected SpawnPoint _SpawnPoint;

		[SerializeField]
		protected int _MaxHealth;

		protected int _health;

		protected HealthManager _healthManager;

		public override GameObject Head => _Head;

		public override GameObject Body => _Body is null ? gameObject : _Body;

		public override NetworkInventory Inventory => _inventory;

		public override Interaction Interaction => _interaction;

		public override ISpawnPoint SpawnPoint => _SpawnPoint;

		public override int Health { 
			get => _health; 
			set 
			{
				_health = value < MinHealth ? MinHealth : value > MaxHealth ? MaxHealth : value;
			}
		}

		public override int MaxHealth { get; } = 100;

		public override int MinHealth { get; } = 0;

		public override HealthManager HealthManager => _healthManager;

		public override GameConsole Console => gameObject.GetComponent<GameConsole>();

		public override ILocation Location { get; } = new SpawnHub();

		public override string RoleName => "Обыватель";

		public override string RoleDescription => "Ваша задача - выбраться из данного измерения.";

		public override IMovement Movement => _netFPC;

		public override void LocalInit()
		{
			_inventory = gameObject.AddComponent<Inventory>();
			_interaction = GetComponent<Interaction>();
			_netFPC = gameObject.AddComponent<FPC>();
			_healthManager = new HealthManager(this);
			_health = _MaxHealth;



			_Body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			_Body.GetComponent<Rigidbody>().mass = 70.0f;

		}

		public override void OnlineInit()
		{
			_inventory = gameObject.AddComponent<NetworkInventory>();

		}

		public void SetMaxHealth(int value) => _MaxHealth = value;
	}
}
