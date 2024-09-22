
using API.Locations;
using API.Locations.Interfaces;
using API.Roles.Interfaces;
using Mirror;
using UnityEngine;

namespace API.Roles
{
	[RequireComponent(typeof(NetworkTransformUnreliable), typeof(NetworkRigidbodyUnreliable))]
	public abstract class MovableRole : Role, IMovableRole
	{
		public virtual GameObject rolePrefab { get; }
		/// <summary>
		/// FPC контроллер объекта
		/// </summary>
		public abstract IMovement Movement { get; }

		/// <summary>
		/// Простравнство или локация в которой находится объект
		/// </summary>
		public abstract ILocation Location { get; }

		/// <summary>
		/// Точка спавна объекта
		/// </summary>
		public abstract ISpawnPoint SpawnPoint { get; }
	}
}
