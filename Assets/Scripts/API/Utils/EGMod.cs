using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace API.Utils
{
	public class EGMod
	{
		public virtual void OnEnable()
		{
			EGModManager.RegisterMod(this);
		}

		public virtual void OnDisable()
		{

		}

	}
}
