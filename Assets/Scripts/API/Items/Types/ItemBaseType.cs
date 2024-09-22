using API.Items.Interfaces;
using System;

namespace API.Items.Types
{
	public abstract class ItemBaseType
	{
		public abstract Item item { get; set; }
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract VisualizeItem visual { get; }
	}
}
