using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using System.Collections;
using API.Items.Interfaces;
using API.Items.Types;
using API.Items;

namespace Game.Items.Types
{
	public class Can : ToolType
	{
		public override BaseItem item { get => _item; set => _item = value; }
		public override string Name => "Can";

		public override string Description => "Is drinking can";

		public override VisualizeItem visual => null!;

		private BaseItem _item;

		public override void Use()
		{
			item.StartCoroutine(en());
		}

		public IEnumerator en()
		{
			Debug.Log("Start drink...");
			yield return new WaitForSeconds(2);
			Debug.Log("Stop drinl!");
		}
	}
}
