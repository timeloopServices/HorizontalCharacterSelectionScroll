using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HorizontalScroll
{
	public class HorizontalScrollManager : MonoBehaviour
	{
		public GameObject ElementPrefab;
		public GameObject ScrollParent;
		public List<ScrollElementInfo> ListOfElementInfo;
	}
}