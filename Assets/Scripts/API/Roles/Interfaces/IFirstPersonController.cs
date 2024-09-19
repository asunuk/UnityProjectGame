using UnityEngine;

namespace API.Roles.Interfaces
{
	public interface IFirstPersonController : ICameraController, IMovement
	{
		public GameObject Head { get; }
	}
}
