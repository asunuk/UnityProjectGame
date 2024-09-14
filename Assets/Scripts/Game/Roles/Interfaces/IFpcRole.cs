using Game.Locations;
using Game.Roles.PlayerComponents;

namespace Game.Roles.Interfaces
{
	public interface IFpcRole
	{
		public FirstPersonController FPC { get; }
		public Location Location { get; }
	}
}
