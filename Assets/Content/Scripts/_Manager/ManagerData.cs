using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerData : MonoBehaviour {
	public static ManagerData instance {
		get {
			return Resources.Load<ManagerData>("Manager Data");
		}
	}

	public GameObject GetEntity(string name) {
		foreach (Transform item in transform) {
			if(item.name == name) {
				return item.gameObject;
			}
		}
		return null;
	}
}
