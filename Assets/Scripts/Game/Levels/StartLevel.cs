using Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Levels
{
	public class StartLevel : Level
	{

		public override LevelType levelType => LevelType.StartLevel;
		public override Chunk[,] levelMap => null;
		public override float gravity => 9.81f;
	}
}
