using Game.Roles.Interfaces;
using System;
using System.Collections;
using System.ComponentModel.Design;
using UnityEngine;

namespace Game.Roles.Managers
{
	[Serializable]
	public class HealthManager
	{
		protected readonly IHealth IHealth;
		public HealthManager(IHealth IHealth)
		{
			this.IHealth = IHealth;
		}

		public void Reduce(int amount)
		{
			IHealth.Health = IHealth.Health - amount < IHealth.MinHealth ? IHealth.MinHealth : IHealth.Health - amount;
		}

		public void Add(int amount)
		{
			IHealth.Health = IHealth.Health + amount > IHealth.MaxHealth ? IHealth.MaxHealth : IHealth.Health + amount;
		}
	}
}