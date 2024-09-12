using Game.Console.Commands;
using Game.Roles;
using Game.Roles.PlayerComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Util;

namespace Game.Console
{
	public class GameConsole : MonoBehaviour
	{
		public Player player;
		public InputField commandLine;
		public GameObject console;
		public ScrollRect scrollRect;
		public Text consoleText;
		public CommandManager commandManager;
		public ConsoleManager consoleManager;
		public float panelSizeX, panelSizeY, commandLineSizeX, commandLineSizeY;

		public KeyCode
			commandLineCallKey1 = KeyCode.LeftControl,
			commandLineCallKey2 = KeyCode.C,
			sendCommandKey = KeyCode.KeypadEnter;

		private bool isCMDVisible = false;
		private void Start()
		{
			console.SetActive(false);
		}

		private void Update()
		{
			if (Input.GetKey(commandLineCallKey1) && Input.GetKeyDown(commandLineCallKey2))
			{
				isCMDVisible = true;
				console.SetActive(isCMDVisible);
				player.GetComponent<FirstPersonController>().freezy = isCMDVisible;
				UnityEngine.Cursor.lockState = CursorLockMode.None;
				UnityEngine.Cursor.visible = isCMDVisible;
				Init();

			} else if (isCMDVisible && Input.GetKeyDown(KeyCode.Escape))
			{
				isCMDVisible = false;
				console.SetActive(isCMDVisible);
				UnityEngine.Cursor.lockState = CursorLockMode.Locked;
				UnityEngine.Cursor.visible = isCMDVisible;
			}

			Debug.Log(consoleText.text.Split('\n').Length);
		}
		 
		protected void Init()
		{
			consoleManager = new(this);
			commandManager = new(consoleManager, "Configs/Game/commands.json");
			commandManager.RegisterCommand(new Spawn());
			commandManager.RegisterCommand(new Help(commandManager));
			commandManager.RegisterCommand(new Clear());

			console.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
			console.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
			console.GetComponent<RectTransform>().sizeDelta = new Vector2(panelSizeX, panelSizeY);
			console.GetComponent<RectTransform>().anchoredPosition = new Vector2(panelSizeX / 2, -panelSizeY / 2);

			scrollRect.content.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
			scrollRect.content.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
			scrollRect.content.GetComponent<RectTransform>().sizeDelta = new Vector2(panelSizeX, 0);

			consoleText.fontSize = (int) ((panelSizeX + panelSizeY) / 60);

			commandLine.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
			commandLine.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
			commandLine.GetComponent<RectTransform>().sizeDelta = new Vector2(commandLineSizeX, commandLineSizeY);
			commandLine.GetComponent<RectTransform>().anchoredPosition = new Vector2(commandLineSizeX / 2, -commandLineSizeY / 2);

			commandLine.textComponent.fontSize = (int)((commandLineSizeX + commandLineSizeY) / 60);

			commandLine.text = null;
			commandLine.onSubmit.AddListener(delegate { onSubmit(commandLine); });
			commandLine.onValueChanged.AddListener(delegate { onValueChanged(commandLine); });
			commandLine.onEndEdit.AddListener(delegate { onEndEdit(commandLine); });
		}

		private void onSubmit(InputField inputField)
		{
			Debug.Log("Submit: " + inputField.text);
		}
		private void onValueChanged(InputField inputField)
		{
			
		}

		private void onEndEdit(InputField inputField)
		{

			{
				try
				{
					if (inputField.text[0] == '/')
					{
						commandManager.Execute(commandLine.text.Substring(1));
					}
				}
				catch (CommandManager.NullCommandException)
				{
					Send($"{ColorText.Red}Комманды '{inputField.text.Split(' ')[0].Substring(1)}' не существует!{ColorText.End}");
				}
				catch (IndexOutOfRangeException) {
				}
				inputField.text = null;
			}
		}

		private int consoleTextSize = 0;
		public void Send(string text)
		{
			consoleText.text += $"{text}\n";
			consoleTextSize = consoleText.fontSize * 2;
			scrollRect.content.GetComponent<RectTransform>().sizeDelta = new Vector2(panelSizeX, scrollRect.content.GetComponent<RectTransform>().sizeDelta.y + (consoleText.fontSize * 2));
		}
	}
}
