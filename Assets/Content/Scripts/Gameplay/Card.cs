using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardLocation {
    Hand,
    Board,
    Hero,
}

[System.Serializable]
public class Card
{
    public CardLocation location;

	public string name;
	public int controller;

	public int manaCost;

	public int attack;
	public int maxAttack;

	public int health;
	public int maxHealth;

	public Entity entity
	{
		get
		{
			var r = Data.instance.getEntity(name);
			if (r == null)
			{
				Debug.LogError("Could not find entity with name '" + name + "' in Card.cs");
			}
			return r;
		}
	}
}
