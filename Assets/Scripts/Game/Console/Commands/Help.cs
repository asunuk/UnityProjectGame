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
	public class Help : Command
	{

		public override string name => "help";
		public override string description => "показывает все доступные комманды.";

		private CommandManager commandManager;

		public Help(CommandManager commandManager)
		{
			this.commandManager = commandManager;
		}

		public override bool CommandExecutor(ICommandSender commandSender, string[] commandArgs)
		{
			if(commandSender is Player player)
			{
				foreach (Command command in commandManager.getCommandsList())
				{
					player.console.Send($"{ColorText.Orange}{command.name}{ColorText.End} - {command.description}");
				}
            }
			return true;
		}
	}
}
