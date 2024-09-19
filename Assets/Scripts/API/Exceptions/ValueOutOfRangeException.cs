

using System;

namespace API.Exceptions
{
	public class ValueOutOfRangeException : Exception
	{
		public int Value { get; protected set; }
		public ValueOutOfRangeException() : base() { }
		public ValueOutOfRangeException(string message, int value) : 
			base(message) 
		{
			Value = value;
		}
	}
}
