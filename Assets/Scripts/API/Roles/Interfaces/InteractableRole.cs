using API.Roles.Components;
using API.Roles.PlayerComponents;

namespace API.Roles.Interfaces
{
	public interface InteractableRole
	{
		public NetworkInventory Inventory { get; }
		public Interaction Interaction { get; }
	}
}
