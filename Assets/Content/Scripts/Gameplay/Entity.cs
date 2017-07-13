using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType {
    Invalid,
    Spell,
    Minion,
    Hero,
}
public enum EntityLocation
{
    Invalid,
    Deck,
    Hand,
    Board,
    Hero,
}

[System.Serializable]
public class Entity {
	public string name;
    public EntityType type;
    public EntityLocation location;

	public int manaCost;
	public string title;
	public string description;
	public string art;

    public int attack;
    public int attackMax;
    public int health;
    public int healthMax;

    public int controller;
    public int index;

    public List<Event> events;


    public Entity clone() {
        var copy = new Entity();

        copy.name = name;
        copy.type = type;
        copy.location = location;

        copy.manaCost = manaCost;
        copy.title = title;
        copy.description = description;
        copy.art = art;

        copy.attack = attack;
        copy.attackMax = attackMax;
        copy.health = health;
        copy.healthMax = healthMax;

        copy.controller = controller;
        copy.index = index;

        foreach (var item in events)
        {
            events.Add(item.clone());
        }

        return copy;
    }
}
