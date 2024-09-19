namespace API.Console.Commands
{
	public abstract class Command
	{
		public abstract string name { get; }
		public abstract string description { get; }

		public abstract bool CommandExecutor(ICommandSender sender, string[] args);
	}
}
