using Game.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Events.Interfaces
{
	public interface IPlayerEvent : IEvent
	{
		Player player { get; }
	}
}
