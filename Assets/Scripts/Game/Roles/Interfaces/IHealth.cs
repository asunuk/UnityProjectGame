using System;

namespace Game.Roles.Interfaces
{
	public interface IHealth
	{
		public int Health { get; set; }
		public int MaxHealth { get; }
		public int MinHealth { get; }
	}
}
