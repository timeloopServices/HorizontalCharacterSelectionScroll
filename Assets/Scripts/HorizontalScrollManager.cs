using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace HorizontalScroll
{
	public class HorizontalScrollManager : MonoBehaviour
	{
		private const float SCROLLBUFFER = 250.0f;

		public GameObject ElementPrefab;
		public GameObject ScrollParent;
		public List<ScrollElementInfo> ListOfElementInfo;
		public Animator selectedElementAnimator;

		private List<ScrollElement> ListOfScrollObjects;
		private float scaleFactor;
		private float centerPositionX;
		private float leftLimitX;
		private float rightLimitX;
		private float bufferX;
		private RectTransform parentRactTransform;

		public float GetScaleFactor() {
			return scaleFactor;
		}

		public float GetCenterPositionX() {
			return centerPositionX;
		}

		public float GetLeftLimit() {
			return leftLimitX;
		}

		public float GetRightLimit() {
			return rightLimitX;
		}



		public void ElementCameInCenter(int id) {
			float moveDist = (id - 1) * GetEachElementWidth () * -1.0f;
			Debug.Log (id +" Element in center " + "shift :: "+moveDist);
			parentRactTransform.localPosition = new Vector3 ((id-1) * GetEachElementWidth () * -1.0f,
															 parentRactTransform.localPosition.y,
															 parentRactTransform.localPosition.z);

			for (int i = 0; i < ListOfScrollObjects.Count; i++) {
				ScrollElement element = ListOfScrollObjects [i];
				if (i == (id - 1)) {
					element.gameObject.GetComponentInChildren<Image>().gameObject.transform.localScale = Vector3.one * 1.2f;
				} else {
					element.gameObject.GetComponentInChildren<Image>().gameObject.transform.localScale = Vector3.one * 1.0f;
				}
			}

			selectedElementAnimator.SetInteger ("Play_Animation", id);
		}

		private float GetEachElementWidth() {
			return ElementPrefab.GetComponent<LayoutElement> ().minWidth;
		}

		private void Start() {
			InitializeHorizontalScroll ();
			bufferX = SCROLLBUFFER * scaleFactor;	
			StartCoroutine (SetCenterPosition ());
			parentRactTransform = ScrollParent.GetComponent<RectTransform> ();
		}

		private void InitializeHorizontalScroll() {

			scaleFactor = ScrollParent.GetComponentInParent<Canvas> ().scaleFactor;
			ListOfScrollObjects = new List<ScrollElement> ();

			foreach (ScrollElementInfo elementInfo in ListOfElementInfo) {
				print("****************Element "+elementInfo.ElementId+" *******************");
				print ("Element Name :: " + elementInfo.ElementName);
				print ("Sprite Path :: " + elementInfo.SpriteResourcePath);

				GameObject scrollElementGO = Instantiate (ElementPrefab);

				//set information
				ScrollElement scrollElement = scrollElementGO.GetComponent<ScrollElement>();
				scrollElement.SetElement(this,elementInfo);

				//set parent
				scrollElementGO.transform.SetParent(ScrollParent.transform,false);

				//assign text
				scrollElementGO.GetComponentInChildren<Text> ().text = elementInfo.ElementName;

				//assign Image
				Sprite loadedSprite = Resources.Load<Sprite>(elementInfo.SpriteResourcePath);
				scrollElementGO.GetComponentInChildren<Button> ().gameObject.GetComponent<Image> ().sprite = loadedSprite;

				ListOfScrollObjects.Add (scrollElement);

				selectedElementAnimator.SetInteger ("Play_Animation", 1);
			}
				
		}

		private IEnumerator SetCenterPosition() {
			yield return new WaitForEndOfFrame ();
			centerPositionX = ListOfScrollObjects [0].gameObject.transform.TransformPoint (ListOfScrollObjects [0].gameObject.transform.position).x;
			leftLimitX = centerPositionX - bufferX;
			rightLimitX = centerPositionX + bufferX;}
		}
}