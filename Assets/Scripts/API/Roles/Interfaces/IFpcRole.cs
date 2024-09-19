using API.Locations;
using API.Locations.Interfaces;
using API.Roles.PlayerComponents;

namespace API.Roles.Interfaces
{
	public interface IFpcRole
	{
		public IFirstPersonController FPC { get; }
		public ILocation Location { get; }
	}
}
