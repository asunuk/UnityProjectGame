
using Game.Console;
using Game.Console.Commands;
using Game.Levels;
using Game.Roles.Exceptions;
using Game.Roles.Interfaces;
using Game.Roles.Managers;
using Game.Roles.PlayerComponents;
using System;
using UnityEngine;

namespace Game.Roles
{
	[RequireComponent(typeof(FirstPersonController), typeof(Inventory))]
	public class Player : MonoBehaviour, ICommandSender, IRole, IHealth
	{
		public CharacterController CharacterController => GetComponent<CharacterController>();
		public FirstPersonController FPC => _FPC;
		public Inventory Inventory => _Inventory;
		public Level Level => _Level;
		public HealthManager HealthManager => _HealthManager;

		[Header("Основные параметры Player")]
		public GameObject Body;

		[SerializeField]
		protected FirstPersonController _FPC;

		[SerializeField]
		protected Inventory _Inventory;

		[Header("Основные переменные для Player")]
		protected Level _Level;

		[SerializeField]
		protected int _Health;

		[SerializeField]
		protected int _MaxHelath;

		public GameConsole console => gameConsole;

		[SerializeField]
		private GameConsole gameConsole;

		public string RoleName { get; }
		public int Health { 
			get => _Health; 
			set
			{
				Health = value > MinHealth && value < MaxHealth ? value : Health;
			}
		}
		public int MaxHealth => _MaxHelath;
		public int MinHealth => 0;

		protected HealthManager _HealthManager;

		private void Start()
		{
			_HealthManager = new(this);

		}

		public void SetInventory(Inventory newInventory)
		{

		}
	}

	[Serializable]
	public class PlayerData
	{
		public readonly Vector3 position;
		public readonly Quaternion cameraRotation, playerRotation;
		public readonly InventoryData inventoryData;
		public readonly IHealth health;

		public PlayerData(Player player)
		{
			position = player.Body.transform.position;
			cameraRotation = player.FPC.Camera.transform.localRotation;
			playerRotation = player.gameObject.transform.rotation;
			inventoryData = new InventoryData(player.Inventory);
			health = player;
		}
	}
}