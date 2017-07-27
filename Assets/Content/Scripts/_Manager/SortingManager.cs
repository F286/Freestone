using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortingManager : MonoBehaviour {
	public void LateUpdate() {
		int index = 1;
		foreach (var item in GetComponentsInChildren<SortingGroup>()) {
			item.sortingOrder = -index;
			item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, 0.1f * index);
			index += 1;
		}
	}
}
