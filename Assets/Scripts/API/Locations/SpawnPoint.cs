using API.Locations.Interfaces;
using System;
using UnityEngine;

namespace API.Locations
{
	public class SpawnPoint : MonoBehaviour, ISpawnPoint
	{

		public virtual Vector3 Position { get; }

		public virtual float protectDistance { get; }
	}
}