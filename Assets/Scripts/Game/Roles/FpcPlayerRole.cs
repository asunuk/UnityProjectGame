
using Game.Console;
using Game.Console.Commands;
using Game.Locations;
using Game.Roles.Exceptions;
using Game.Roles.Interfaces;
using Game.Roles.Managers;
using Game.Roles.PlayerComponents;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Roles
{
	public abstract class FpcPlayerRole : FpcRole, IHealth, InteractableRole, ICommandSender
	{
		public abstract GameObject Body { get; }
		public abstract int Health { get; set; }
		public abstract int MaxHealth { get; }
		public abstract int MinHealth { get; }

		public abstract Inventory Inventory { get; protected set; }
		public abstract Interaction Interaction { get; protected set; }

		public abstract HealthManager HealthManager { get; }

		public abstract GameConsole console { get; }


		//[SerializeField]
		//protected FirstPersonController _FPC;

		//[SerializeField]
		//protected Inventory _Inventory;

		//[Header("Основные переменные для Player")]
		//protected Level _Level;

		//[SerializeField]
		//protected int _Health;

		//[SerializeField]
		//protected int _MaxHelath;

		public virtual void SetInventory(Inventory newInventory)
		{

		}

		public virtual void AddInventory(Inventory newInventory)
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

		public PlayerData(FpcPlayerRole player)
		{
			position = player.Body.transform.position;
			cameraRotation = player.FPC.Camera.transform.localRotation;
			playerRotation = player.gameObject.transform.rotation;
			inventoryData = new InventoryData(player.Inventory);
			health = player;
		}
	}
}