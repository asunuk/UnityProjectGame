using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Console.Commands
{
	public interface ICommandSender
	{
		public GameConsole Console { get; }
	}
}
