using UnityEngine;
using Game.Entityes.Types;

namespace Game.Entityes
{
	public abstract class Entity : MonoBehaviour
	{
		public abstract EntityType entityType { get; }
		public bool isAlive => _isAlive;
		public int health
		{
			get => _health;
			set {
				if (value > maxHealth)
					health = maxHealth;
				else if(health - value < 0)
					health = 0;
				else health = value; 
			}
		}
		protected int _health, maxHealth;
		protected bool _isAlive;

		public void AddHealth(int value)
		{
			health += value * value > 0 ? 1 : -1;
		}

		public void SubHealth(int value)
		{
			health -= value * value < 0 ? 1 : -1;
		}
		public void setAlive(bool value)
		{

		}
		public abstract void Spawn();
		public abstract void Kill();
		public abstract void ActionsHandler();
	}
}
