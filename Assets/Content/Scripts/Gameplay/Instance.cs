using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum CardLocation {
//    None,
//    Hand,
//    Board,
//    Hero,
//}

[System.Serializable]
public class Instance
{
    public EntityLocation location;

	public string name = "";
	public int controller = -1;

	public int manaCost;

	public int attack;
	public int maxAttack;

	public int health;
	public int maxHealth;

    public static Entity empty = new Entity();
	public Entity entity
	{
		get
		{
            if(name == "") {
                return empty;
            }
			var r = Data.instance.getEntity(name);
            if (r.type == EntityType.Invalid)
			{
				Debug.LogError("Could not find entity with name '" + name + "' in Card.cs");
			}
			return r;
		}
	}
}
