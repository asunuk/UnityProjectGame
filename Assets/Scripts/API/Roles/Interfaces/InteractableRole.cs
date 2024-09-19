using API.Roles.PlayerComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Roles.Interfaces
{
	public interface InteractableRole
	{
		public Inventory Inventory { get; }
		public Interaction Interaction { get; }
	}
}
