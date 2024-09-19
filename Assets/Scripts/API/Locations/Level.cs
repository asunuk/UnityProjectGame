using API.Locations.Interfaces;
using API.Managers.Items;
using System;
using UnityEngine;

namespace API.Locations
{
	[Serializable]
	public struct Chunk
	{
		public readonly int lx, ly;
		public readonly short indexChunkGameObject;

		public Chunk(int lx, int ly, short indexChunkGameObject)
		{
			this.lx = lx;
			this.ly = ly;
			this.indexChunkGameObject = indexChunkGameObject;
		}
	}
	[RequireComponent(typeof(ItemManager))]
	public abstract class Level : MonoBehaviour, ILocation
	{
		public ItemManager itemManager => GetComponent<ItemManager>();
		public abstract LevelType levelType { get; }
		public abstract Chunk[,] levelMap { get; }
		public abstract float gravity { get; }
	}
}
