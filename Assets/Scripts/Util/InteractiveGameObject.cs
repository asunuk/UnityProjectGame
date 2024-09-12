using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Util
{
	public abstract class InteractiveGameObject
	{
		public GameObject gameObject { get; }
		public InteractiveGameObject(GameObject gameObject)
		{
			this.gameObject = gameObject;
		}
		public abstract void InteractAction();
	}
}
