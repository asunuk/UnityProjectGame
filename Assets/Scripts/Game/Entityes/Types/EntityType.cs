﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entityes.Types
{
	public interface EntityType
	{
		public string pathToEntityGameObject { get; }
		public int maxHealth { get; }
	}
}
