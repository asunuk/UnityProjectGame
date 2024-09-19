using API.Locations;
using UnityEngine;

namespace Game.SpawnPoints
{
	public class SimpleSpawnPoint : SpawnPoint
	{
		[SerializeField]
		protected float _protectDistance;

		protected Vector3 _Position;

		public override Vector3 Position => _Position;

		public override float protectDistance => _protectDistance;

		protected void Start()
		{
			_Position = gameObject.transform.position;

		}
	}
}
