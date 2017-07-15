﻿using System.Collections;
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
	public void Set(string name, string setTo) {
		for (int i = 0; i < attributes.Count; i++) {
			if(attributes[i].type == name) {
				attributes[i].data = setTo;
				break;
			}
		}
	}

	public bool isFriendly {
		get {
			return GetComponentInParent<Player>().number == ManagerGame.instance.currentPlayerIndex;
		}
	}
	public Player player {
		get {
			return GetComponentInParent<Player>();
		}
	}
	public int manaCost {
		get {
			return int.Parse(Get("mana_cost"));
		}
		set {
			Set("mana_cost", value.ToString());
		}
	}
	public int mana {
		get {
			return int.Parse(Get("mana"));
		}
		set {
			Set("mana", value.ToString());
		}
	}
}
