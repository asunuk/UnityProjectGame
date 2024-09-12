using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Console.Commands
{
	public class CommandManager
	{
		public readonly ConsoleManager consoleManager;
		public readonly string commandsFilePath;

		protected Dictionary<string, Command> commandsDictionary = new Dictionary<string, Command>();
		public CommandManager(ConsoleManager consoleManager, string commandsFilePath)
		{
			this.consoleManager = consoleManager;
			this.commandsFilePath = Application.dataPath + "/" + commandsFilePath;
			if (!File.Exists(commandsFilePath))
			{
				File.Create(this.commandsFilePath).Close();
			}
		}
		public class NullCommandException : Exception
		{
			public NullCommandException() : base() { }
			public NullCommandException(string message) : base(message) { }
			public NullCommandException(string message, Exception inner) : base(message, inner) { }
		}

		public void RegisterCommand(Command command)
		{
			if(commandsDictionary.ContainsKey(command.name) is false) commandsDictionary.Add(command.name, command);
			CommandsJsonConfigUpdate();
		}

		public void UnregisterCommand(Command command)
		{
			if (commandsDictionary.ContainsKey(command.name) is false) commandsDictionary.Add(command.name, command);
			CommandsJsonConfigUpdate();
		}

		public void Execute(string commandLine)
		{
			string[] commandArgs = commandLine.Split(' ');
			if (commandsDictionary.ContainsKey(commandArgs[0]) is false) throw new NullCommandException();
			else
			{
				commandsDictionary[commandArgs[0]].CommandExecutor(consoleManager.console.player, commandArgs.Skip(1).ToArray());
			}
		}

		public List<Command> getCommandsList()
		{
			return commandsDictionary.Values.ToList();
		}

		public void CommandsJsonConfigUpdate()
		{
			StreamWriter fs =  new StreamWriter(new FileStream(commandsFilePath, FileMode.Create));
			string json = JsonUtility.ToJson(commandsDictionary);
			fs.Write(json);
			fs.Close();
		}

		public async Task CommandsJsonConfigUpdateAsync()
		{
			StreamWriter fs = new StreamWriter(new FileStream(commandsFilePath, FileMode.Create));
			string json = JsonUtility.ToJson(commandsDictionary);
			await fs.WriteAsync(json);
			fs.Close();
		}

		public void CommandsDictionaryUpdate()
		{
			StreamReader fs = new StreamReader(new FileStream(commandsFilePath, FileMode.OpenOrCreate));
			string json = fs.ReadToEnd();
			List<string> commandNames = JsonUtility.FromJson<List<string>>(json);
			foreach (string commandName in commandNames)
			{
				if (commandsDictionary.ContainsKey(commandName) is false) commandsDictionary.Add(commandName, null);
			}
			foreach (string commandName in commandsDictionary.Keys.ToList())
			{
				if (commandNames.Contains(commandName) is false) commandsDictionary.Remove(commandName);
			}
			fs.Close();
		}

		public async Task CommandsDictionaryUpdateAsync()
		{
			StreamReader fs = new StreamReader(new FileStream(commandsFilePath, FileMode.OpenOrCreate));
			string json = await fs.ReadToEndAsync();
			List<string> commandNames = JsonUtility.FromJson<List<string>>(json);
			foreach (string commandName in commandNames)
			{
				if (commandsDictionary.ContainsKey(commandName) is false) commandsDictionary.Add(commandName, null);
			}
			foreach (string commandName in commandsDictionary.Keys.ToList())
			{
				if (commandNames.Contains(commandName) is false) commandsDictionary.Remove(commandName);
			}
			fs.Close();
		}

	}
}
