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
				return;
			}
		}
		var data = new EntityDataObject();
		data.type = name;
		data.data = setTo;
		attributes.Add(data);
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
			int r = 0;
			if (!int.TryParse(Get("mana_cost"), out r)) {
				print("Could not parse 'mana_cost' for entity with name: " + name);
			}
			return r;
		}
		set {
			Set("mana_cost", value.ToString());
		}
	}
	public int mana {
		get {
			int r = 0;
			if (!int.TryParse(Get("mana"), out r)) {
				print("Could not parse 'mana' for entity with name: " + name);
			}
			return r;
		}
		set {
			Set("mana", value.ToString());
		}
	}
	public int maxMana {
		get {
			int r = 0;
			if (!int.TryParse(Get("max_mana"), out r)) {
				print("Could not parse 'max_mana' for entity with name: " + name);
			}
			return r;
		}
		set {
			Set("max_mana", value.ToString());
		}
	}
	public int attack {
		get {
			int r = 0;
			if(!int.TryParse(Get("attack"), out r)) {
				print("Could not parse 'attack' for entity with name: " + name);
			}
			return r;
		}
		set {
			Set("attack", value.ToString());
		}
	}
	public int health {
		get {
			int r = 0;
			if (!int.TryParse(Get("health"), out r)) {
				print("Could not parse 'health' for entity with name: " + name);
			}
			return r;
		}
		set {
			Set("health", value.ToString());
		}
	}
	public bool canAttack {
		get {
			return Get("can_attack") == "True";
		}
		set {
			Set("can_attack", value.ToString());
		}
	}
}
