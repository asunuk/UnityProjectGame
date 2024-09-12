using Game.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Game.Console.Commands
{
	public abstract class Command
	{
		public abstract string name { get; }
		public abstract string description { get; }

		public abstract bool CommandExecutor(ICommandSender sender, string[] args);
	}
}
