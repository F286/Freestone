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

}
