using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace API.GUI
{
	public interface ITextLabel
	{
		public Text Text { get; }
		public Font Font { get; }
		public string Value { get; set; }
	}
}
