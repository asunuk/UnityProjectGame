using API.Locations;
using API.Locations.Interfaces;
using API.Roles.PlayerComponents;

namespace API.Roles.Interfaces
{
	public interface IMovableRole
	{
		public IMovement Movement { get; }
		public ILocation Location { get; }
	}
}
