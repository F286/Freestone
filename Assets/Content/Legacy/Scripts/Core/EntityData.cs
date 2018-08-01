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
			if (attributes[i].type == name) {
				attributes[i].data = setTo;
				return;
			}
		}
		var data = new EntityDataObject();
		data.type = name;
		data.data = setTo;
		attributes.Add(data);
	}
	public EnchantmentData EvaluateEnchantments() {
		var data = new EnchantmentData(getAttack(), getHealth());
		var enchantments = GetComponentsInChildren<IEnchantment>();
		foreach (var item in enchantments) {
			data = item.Evaluate(data);
		}
		return data;
	}
	public bool isFriendly {
		get {
			return this.GetPlayer().number == ManagerGame.instance.currentPlayerIndex;
		}
	}
	public Player player {
		get {
			return this.GetPlayer();
		}
	}
	public EntityData target {
		get {
			return Core.PathToEntity(Get("target"));
		}
		set {
			Set("target", Core.GameObjectToPath(value.gameObject));
		}
	}
	public GameObject targetGraphic {
		set {
			Set("target", Core.GameObjectToPath(value));
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
	public int getAttack() {
		int r = 0;
		if (!int.TryParse(Get("attack"), out r)) {
			print("Could not parse 'attack' for entity with name: " + name);
		}
		return r;
	}
	public int getHealth() {
		int r = 0;
		if (!int.TryParse(Get("health"), out r)) {
			print("Could not parse 'health' for entity with name: " + name);
		}
		return r;
	}
	public int attack {
		get {
			var data = EvaluateEnchantments();
			return data.attack;
		}
	}
	public int health {
		get {
			var data = EvaluateEnchantments();
			return data.health;
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
