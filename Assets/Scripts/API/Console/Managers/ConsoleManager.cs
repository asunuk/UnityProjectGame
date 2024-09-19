using API.Console.Commands;
using API.Roles;
using UnityEditor;
using UnityEngine;

namespace API.Console
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