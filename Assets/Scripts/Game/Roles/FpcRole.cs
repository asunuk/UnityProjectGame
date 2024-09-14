
using Game.Locations;
using Game.Roles.Interfaces;
using Game.Roles.PlayerComponents;

namespace Game.Roles
{
	public abstract class FpcRole : Role, IFpcRole
	{
		/// <summary>
		/// FPC контроллер объекта.
		/// </summary>
		public abstract FirstPersonController FPC { get; protected set; }
		/// <summary>
		/// Простравнство или локация в которой находится объект
		/// </summary>
		public abstract Location Location { get; protected set; }
	}
}
