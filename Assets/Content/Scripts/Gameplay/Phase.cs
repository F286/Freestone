using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Phase : MonoBehaviour {
    public List<Event> events;
	public List<Phase> children;
}
