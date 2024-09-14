using Game.Locations.Interfaces;

namespace Game.Locations
{
	public abstract class Location : ILocation
	{
		public abstract float gravity { get; }
	}
}
