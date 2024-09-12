using UnityEngine;

namespace Game.Roles.Interfaces
{
	public interface IFirstPersonController : ICameraController, IMovement
	{
		public GameObject Head { get; }
	}
}
