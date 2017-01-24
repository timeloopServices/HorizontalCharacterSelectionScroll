using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace HorizontalScroll
{
	public class HorizontalScrollManager : MonoBehaviour
	{
		public GameObject ElementPrefab;
		public GameObject ScrollParent;
		public List<ScrollElementInfo> ListOfElementInfo;

		private List<GameObject> ListOfScrollObjects;

		private void Start() {
			ListOfScrollObjects = new List<GameObject> ();

			foreach (ScrollElementInfo elementInfo in ListOfElementInfo) {
				print("****************Element "+elementInfo.ElementId+" *******************");
				print ("Element Name :: " + elementInfo.ElementName);
				print ("Sprite Path :: " + elementInfo.SpriteResourcePath);

				GameObject scrollElement = Instantiate (ElementPrefab);
				scrollElement.transform.SetParent(ScrollParent.transform,false);
				//scrollElement.transform.localScale = Vector3.one;

				//assign text
				scrollElement.GetComponentInChildren<Text> ().text = elementInfo.ElementName;

				//assign Image
				Sprite loadedSprite = Resources.Load<Sprite>(elementInfo.SpriteResourcePath);
				scrollElement.GetComponentInChildren<Button> ().gameObject.GetComponent<Image> ().sprite = loadedSprite;

				ListOfScrollObjects.Add (scrollElement);


			}
		}

	}
}