using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, IOnGlobalEvent {
	public GlobalEventName globalEventName {
		get {
			return GlobalEventName.Any;
		}
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		//print(eventName);
		if(eventName == GlobalEventName.BeginTurn && 
		   GetComponentInParent<Player>().number == ManagerGame.instance.currentPlayer) {
			var maxManaRaw = GetComponent<EntityData>().Get("max_mana");
			var maxMana = int.Parse(maxManaRaw);
			maxMana += 1;
			GetComponent<EntityData>().Set("max_mana", maxMana.ToString());
			GetComponent<EntityData>().Set("mana", maxMana.ToString());
		}
	}
}
