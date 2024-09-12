using Game.Console.Commands;
using Game.Roles;
using UnityEditor;
using UnityEngine;

namespace Game.Console
{
	public class ConsoleManager
	{
		public readonly GameConsole console;
		public ConsoleManager(GameConsole console) 
		{
			this.console = console; 
		}
	}
}