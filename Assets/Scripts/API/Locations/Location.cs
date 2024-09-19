using API.Locations.Interfaces;

namespace API.Locations
{
	public abstract class Location : ILocation
	{
		public abstract float gravity { get; }
	}
}
