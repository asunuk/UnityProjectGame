
using API.Console;
using API.Console.Commands;
using API.Locations;
using API.Roles.Components;
using API.Roles.Exceptions;
using API.Roles.Interfaces;
using API.Roles.Managers;
using API.Roles.PlayerComponents;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace API.Roles
{
	public abstract class PlayerMovableRole : MovableRole, IHealth, InteractableRole, ICommandSender
	{
		public virtual GameObject Head { get; }
		public abstract GameObject Body { get; }
		public abstract int Health { get; set; }
		public abstract int MaxHealth { get; }
		public abstract int MinHealth { get; }

		public abstract NetworkInventory Inventory { get; }
		public abstract Interaction Interaction { get; }

		public abstract HealthManager HealthManager { get; }

		public abstract GameConsole Console { get; }

		public virtual void SetInventory(NetworkInventory newInventory)
		{

		}

		public virtual void AddInventory(NetworkInventory newInventory)
		{

		}
	}
}