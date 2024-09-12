using Game.Items;
using Game.Levels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Levels
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
	public abstract class Level : MonoBehaviour, ISpace
	{
		public ItemManager itemManager => GetComponent<ItemManager>();
		public abstract LevelType levelType { get; }
		public abstract Chunk[,] levelMap { get; }
		public abstract float gravity { get; }
	}
}
