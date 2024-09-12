using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Console.Commands
{
	public interface ICommandSender
	{
		public GameConsole console { get; }
	}
}
