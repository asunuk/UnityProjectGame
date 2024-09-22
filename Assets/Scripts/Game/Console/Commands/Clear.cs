using API.Console.Commands;
using API.Roles;

namespace Game.Console.Commands
{
	public class Clear : Command
	{

		public override string name => "clear";
		public override string description => "очистка консольного меню.";

		public override bool CommandExecutor(ICommandSender commandSender, string[] commandArgs)
		{
			if(commandSender is PlayerMovableRole player)
			{
				player.Console.consoleText.text = null;
            }
			return true;
		}
	}
}
