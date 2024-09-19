using UnityEngine;

namespace API.Locations.Interfaces
{
	public interface ISpawnPoint
	{
		public Vector3 Position { get; }
		public float protectDistance { get; }
	}
}
