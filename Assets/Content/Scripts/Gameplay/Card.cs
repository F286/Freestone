using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
	//public Entity card;
	public string name;
	public int controller;

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
