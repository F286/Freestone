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

	public int manaCost;
	public string title;
	public string description;
	public string art;

	[Header("Assumed to be spell if health is zero")]
	public int attack;
    public int health;

    public List<Event> actions;
    public List<Event> events;
}
