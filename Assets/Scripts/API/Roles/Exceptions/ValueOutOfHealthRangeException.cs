using API.Exceptions;
using API.Roles.Interfaces;

namespace API.Roles.Exceptions
{
	public class ValueOutOfHealthRangeException : ValueOutOfRangeException
	{
		public IHealth IHealth { get; protected set; }
		public ValueOutOfHealthRangeException(string message, int value, IHealth IHealth) : base(message, value)
		{ 
			this.IHealth = IHealth;
		}
	}
}
