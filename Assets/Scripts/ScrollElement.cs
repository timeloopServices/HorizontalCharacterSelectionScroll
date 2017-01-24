using UnityEngine;
using System.Collections;

namespace HorizontalScroll
{
	
	public class ScrollElement : MonoBehaviour
	{
		[SerializeField]
		private ScrollElementInfo myInfo;

	}

	[System.Serializable]
	public class ScrollElementInfo
	{
		public int ElementId = -1;
		public string ElementName = string.Empty;
		public string SpriteResourcePath = string.Empty;
	}

}