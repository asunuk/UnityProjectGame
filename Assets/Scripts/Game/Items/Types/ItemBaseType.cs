﻿using Game.Items.Interfaces;
using System;

namespace Game.Items.Types
{
	public abstract class ItemBaseType
	{
		public abstract BaseItem item { get; set; }
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract VisualizeItem visual { get; }
	}
}
