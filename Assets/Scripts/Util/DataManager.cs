using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Util
{
	public class DataManager
	{
		protected BinaryFormatter formatter = new BinaryFormatter();
		public void Serialize(Object serializableObject, string filePath)
		{
			FileStream fs = new FileStream(filePath, FileMode.Create);
			formatter.Serialize(fs, serializableObject);
			fs.Close();
		}

		public T Deserialize<T>(string filePath) where T : class
		{
			FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
			T data = formatter.Deserialize(fs) as T;
			fs.Close();
			return data;
		}
	}
}
