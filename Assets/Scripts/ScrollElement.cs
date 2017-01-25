using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace HorizontalScroll
{
	
	public class ScrollElement : MonoBehaviour
	{
		[SerializeField]
		private ScrollElementInfo myInfo;
		private HorizontalScrollManager scrollManager;

		private void Update() 
		{
			//Debug.Log (myInfo.ElementId + " PositionX :: " +gameObject.transform.position.x);
		}

		public void SetElement(HorizontalScrollManager scrollManager,ScrollElementInfo info) {
			this.scrollManager = scrollManager;

			myInfo.ElementId = info.ElementId;
			myInfo.ElementName = info.ElementName;
			myInfo.SpriteResourcePath = info.SpriteResourcePath;
		}
	}

	[System.Serializable]
	public class ScrollElementInfo
	{
		public int ElementId = -1;
		public string ElementName = string.Empty;
		public string SpriteResourcePath = string.Empty;
	}
		
}