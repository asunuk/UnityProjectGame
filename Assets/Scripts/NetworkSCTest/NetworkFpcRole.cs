using API.Console;
using API.Locations;
using API.Locations.Interfaces;
using API.Roles;
using API.Roles.Interfaces;
using API.Roles.Managers;
using API.Roles.PlayerComponents;
using System;
using UnityEngine;
namespace NetworkSCTest
{
	public class NetworkFpcRole : FpcPlayerRole
	{
		public override GameObject Body => throw new NotImplementedException();

		public override int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override int MaxHealth => throw new NotImplementedException();

		public override int MinHealth => throw new NotImplementedException();

		public override Inventory Inventory => throw new NotImplementedException();

		public override Interaction Interaction => throw new NotImplementedException();

		public override HealthManager HealthManager => throw new NotImplementedException();

		public override GameConsole Console => throw new NotImplementedException();

		public override IFirstPersonController FPC => throw new NotImplementedException();

		public override ILocation Location => throw new NotImplementedException();

		public override ISpawnPoint SpawnPoint => throw new NotImplementedException();

		public override string RoleName => throw new NotImplementedException();

		public override string RoleDescription => throw new NotImplementedException();
	}
}
