using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Roles.Interfaces
{
	public interface IJumping
	{
		/// <summary>
		/// Возвращает силу прыжка объекта
		/// </summary>
		public float JumpForce { get; set; }
	}
}
