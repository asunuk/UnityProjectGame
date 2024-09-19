
using API.Console;
using API.Console.Commands;
using API.Locations;
using API.Roles.Exceptions;
using API.Roles.Interfaces;
using API.Roles.Managers;
using API.Roles.PlayerComponents;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace API.Roles
{
	public abstract class FpcPlayerRole : FpcRole, IHealth, InteractableRole, ICommandSender
	{
		public abstract GameObject Body { get; }
		public abstract int Health { get; set; }
		public abstract int MaxHealth { get; }
		public abstract int MinHealth { get; }

		public abstract Inventory Inventory { get; }
		public abstract Interaction Interaction { get; }

		public abstract HealthManager HealthManager { get; }

		public abstract GameConsole Console { get; }

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