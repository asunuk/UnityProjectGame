using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Locations
{
	[Serializable]
	public enum LevelType
	{
		StartLevel,
		AccessLabyrinths,
		Basement
	}

	[Serializable]
	public class LevelData
	{
		protected readonly LevelType levelType;
		protected readonly Chunk[,] levelMap;

		public LevelData(Level level)
		{
			levelType = level.levelType;
			levelMap = level.levelMap;
		}
	}

	public class LevelManager
	{
		public LevelData getLevelData(Level level)
		{
			return new(level); 
		}
	}
}
