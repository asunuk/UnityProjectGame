
using API.Locations;
using API.Locations.Interfaces;
using API.Roles.Interfaces;

namespace API.Roles
{
	public abstract class FpcRole : Role, IFpcRole
	{
		/// <summary>
		/// FPC контроллер объекта
		/// </summary>
		public abstract IFirstPersonController FPC { get; }

		/// <summary>
		/// Простравнство или локация в которой находится объект
		/// </summary>
		public abstract ILocation Location { get; }

		/// <summary>
		/// Точка спавна объекта
		/// </summary>
		public abstract ISpawnPoint SpawnPoint { get; }
	}
}
