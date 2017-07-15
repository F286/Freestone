using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityDataObject {
	public string type;
	public string data;
}

public class EntityData : MonoBehaviour {

	public List<EntityDataObject> attributes;

	public string Get(string name) {
		foreach (var item in attributes) {
			if(item.type == name) {
				return item.data;
			}
		}
		return "";
	}
}
