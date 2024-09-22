using Mirror;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace API.Utils
{
	

	
	public struct EGModInfo
	{
		public readonly string mainClassName;
	}

	public class EGLoader : MonoBehaviour
	{
		protected void Awake()
		{
			if(!Directory.Exists(Application.dataPath + "/Prefabs/"))Directory.CreateDirectory(Application.dataPath + "/Prefabs/");
		}
		public static string modsFolderPath => _modsFolderPath;
		private static string _modsFolderPath = $"{Application.dataPath}/Mods";
		//public T Load<T>(string modName) where T : class
		//{
		//	string path = $"{_modsFolderPath}/{modName}";
		//	if (File.Exists(path))
		//	{
		//		if (Path.GetExtension(path) == ".egmod")
		//		{

		//		}
		//	}
		//}

		public static EGModInfo LoadModInfo()
		{
			string[] files = Directory.GetFiles(_modsFolderPath);

			EGModInfo modInfo = new();

			foreach (string file in files)
			{
				string[] egmod = Array.FindAll(Directory.GetFiles(file), element => Path.GetFileName(element) == "egmod.json");
				if (egmod.Length == 1)
				{
					string json = File.ReadAllText(egmod[0]);

					modInfo = JsonConvert.DeserializeObject<EGModInfo>(json)!;
				}
				else files.Where(x => x != file);
			}

			return modInfo;
		}

		public static T LoadAndInstatiatePrefab<T>(string prefabName, Vector3 position, Quaternion rotation) where T : UnityEngine.Object
		{
			T _asset = AssetDatabase.LoadAssetAtPath(Application.dataPath + "/Prefabs/" + prefabName, typeof(UnityEngine.Object)) as T;
			return MonoBehaviour.Instantiate(_asset, position, rotation);
		}

		//public T LoadMod<T>(string modName, EGModInfo modInfo) where T : EGMod
		//{
		//	Assembly assembly = Assembly.LoadFrom($"{_modsFolderPath}/{modName}.dll");
		//	Type type = assembly.GetType(modInfo.mainClassName).IsSubclassOf(typeof(EGMod));
		//	T mod = Activator.CreateInstance(type) as T;
		//	return mod;
		//}
	}
}
