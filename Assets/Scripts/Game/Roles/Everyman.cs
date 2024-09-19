using API.Console;
using API.Locations;
using API.Locations.Interfaces;
using API.Roles;
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
	[RequireComponent
		(typeof(NetworkRigidbodyReliable))
		]

	public class Everyman : FpcPlayerRole
	{
		[Header("Основные компоненты Everyman")]
		[SerializeField]
		protected GameObject _Body;

		[SerializeField]
		protected Inventory _Inventory;

		[SerializeField]
		protected Interaction _Interaction;

		[SerializeField]
		protected FirstPersonController _FirstPersonController;

		[SerializeField]
		protected SpawnPoint _SpawnPoint;

		[SerializeField]
		protected int _MaxHealth;

		protected int _Health;

		protected HealthManager _HealthManager;

		public override GameObject Body => _Body is null ? gameObject : _Body;

		public override Inventory Inventory => _Inventory;

		public override Interaction Interaction => _Interaction;

		public override IFirstPersonController FPC => _FirstPersonController;

		public override ISpawnPoint SpawnPoint => _SpawnPoint;

		public override int Health { 
			get => _Health; 
			set 
			{
				_Health = value < MinHealth ? MinHealth : value > MaxHealth ? MaxHealth : value;
			}
		}

		public override int MaxHealth { get; } = 100;

		public override int MinHealth { get; } = 0;

		public override HealthManager HealthManager => _HealthManager;

		public override GameConsole Console => gameObject.GetComponent<GameConsole>();

		public override ILocation Location { get; } = new SpawnHub();

		public override string RoleName => "Обыватель";

		public override string RoleDescription => "Ваша задача - выбраться из данного измерения.";

		public override void Init()
		{
			_Inventory = GetComponent<Inventory>();
			_Interaction = GetComponent<Interaction>();
			_FirstPersonController = GetComponent<FirstPersonController>();
			_HealthManager = new HealthManager(this);
			_Health = _MaxHealth;

			_Body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			_Body.GetComponent<Rigidbody>().mass = 70.0f;

		}

		public void SetMAxHealth(int value) => _MaxHealth = value;
	}
}
