using UnityEngine;
using UnityEngine.UI;

namespace API.GUI
{
	public class TextLabel : MonoBehaviour, ITextLabel
	{
		[SerializeField]
		protected Text _Text;
		public Font Font { get => _Text.font; protected set => _Text.font = value; }
		public Text Text => _Text;
		public string Value { get => _Text.text; set => _Text.text = value; }
	}
}
