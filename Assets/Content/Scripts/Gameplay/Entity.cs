using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType {
    Invalid,
    Spell,
    Minion,
    Hero,
}

[System.Serializable]
public struct Entity {
	public string name;
    public EntityType type;

	public int manaCost;
	public string title;
	public string description;
	public string art;

	//[Header("Assumed to be spell if health is zero")]
	public int attack;
    public int health;

    //public List<Event> actions;
    public List<Event> events;

    //public EntityType type {
    //    get {
    //        if (health == 0) {
    //            return EntityType.Spell;
    //        }
    //        else if(name.Contains("hero")) {
    //            return EntityType.Hero;
    //        }
    //        else {
    //            return EntityType.Minion;
    //        }
    //    }
    //}
}
