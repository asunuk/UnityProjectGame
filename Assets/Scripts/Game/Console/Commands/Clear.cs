using Game.Items.Types;
using Game.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Util;

namespace Game.Console.Commands
{
	public class Clear : Command
	{

		public override string name => "clear";
		public override string description => "очистка консольного меню.";

		public override bool CommandExecutor(ICommandSender commandSender, string[] commandArgs)
		{
			if(commandSender is Player player)
			{
				player.console.consoleText.text = null;
            }
			return true;
		}
	}
}
