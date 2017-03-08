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
		private RectTransform parentRactTransform;
		private bool startChecking;

		private void Start() {
			parentRactTransform = GetComponentInParent<HorizontalLayoutGroup> ().gameObject.GetComponent<RectTransform>();
			startChecking = false;
			StartCoroutine (startDelay ());
		}

		IEnumerator startDelay() {
			yield return new WaitForSeconds(0.1f);
			startChecking = true;
		}

		private void Update() 
		{
			//Debug.Log (myInfo.ElementId + " PositionX :: " +gameObject.transform.position.x);

			float myPosX = transform.TransformPoint (transform.position).x;

			//print ("positionX :: "+myPosX+" leftlimit :: "+leftLimit+" rightlimit :: "+rightLimit);
			//print("Id : "+myInfo.ElementId+" "+transform.TransformVector(transform.position).x);
			if (myPosX >= scrollManager.GetLeftLimit() && myPosX <= scrollManager.GetRightLimit() && Input.GetMouseButtonUp(0)) {
				
				scrollManager.ElementCameInCenter (myInfo.ElementId);
			}

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