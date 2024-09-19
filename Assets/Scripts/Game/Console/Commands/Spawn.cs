﻿using API.Console.Commands;
using API.Managers.Items;
using API.Roles;
using Game.Items.Types;
using UnityEngine;

namespace Game.Console.Commands
{
	public class Spawn : Command
	{

		public override string name => "spawn";

		public override string description => "spawn entityes or items";

		public override bool CommandExecutor(ICommandSender commandSender, string[] commandArgs)
		{
			if(commandSender is FpcPlayerRole player)
			{
				if (commandArgs[0] == "item")
				{
					switch (commandArgs[1])
					{
						case "can":
							if (commandArgs[2] is not null)
							{
								for (int i = 0; i < int.Parse(commandArgs[2]); i++)
								{
									ItemManager.SpawnItem<Can>(player.transform.position + (Vector3.up * 5));
								}
							}
							break;
						default:
							break;
					}
				}
				else return false;
            }
			return true;
		}
	}
}
