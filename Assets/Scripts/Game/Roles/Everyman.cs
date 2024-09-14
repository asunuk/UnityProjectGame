using Game.Console;
using Game.Locations;
using Game.Roles.Managers;
using Game.Roles.PlayerComponents;
using UnityEngine;

namespace Game.Roles
{
	[RequireComponent(typeof(Inventory), typeof(Interaction), typeof(Rigidbody))]
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

		public override GameObject Body => _Body is null ? gameObject : _Body;

		public override Inventory Inventory { get => _Inventory; protected set => _Inventory = value; }

		public override Interaction Interaction { get => _Interaction; protected set => _Interaction = value; }

		public override FirstPersonController FPC { get => _FirstPersonController; protected set => _FirstPersonController = value; }

		public override int Health { get; set; }

		public override int MaxHealth { get; } = 100;

		public override int MinHealth { get; } = 0;

		public override HealthManager HealthManager { get; }

		public override GameConsole console => gameObject.GetComponent<GameConsole>();


		public override Location Location { get; protected set; } = new SpawnHub();

		public override string RoleName => "Обыватель";

		protected override void Init()
		{
			Inventory = GetComponent<Inventory>();
			Interaction = GetComponent<Interaction>();
			FPC = GetComponent<FirstPersonController>();

			_Body.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			_Body.GetComponent<Rigidbody>().mass = 70.0f;

		}
	}
}
