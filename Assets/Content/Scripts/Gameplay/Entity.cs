using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum EntityType {
//    Card,
//    Minion,
//    Hero,
//}

[System.Serializable]
public class Entity {
	//public EntityType type;
	public string name;
    public List<Event> actions;
    public List<Event> events;
}
