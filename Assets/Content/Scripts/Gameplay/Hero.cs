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
		var player = GetComponentInParent<Player>();
		// Start of Turn
		if (eventName == GlobalEventName.BeginTurn && 
		    player.number == ManagerGame.instance.currentPlayerIndex) {
			
			var entity = GetComponent<EntityData>();

			// Increase mana
			entity.maxMana = Math.Min(entity.maxMana + 1, 10);
			entity.mana = entity.maxMana;

			// Draw card
			if (player.deck.transform.childCount > 0) {
				player.deck.transform.GetChild(0).SetParent(player.hand.transform);
			}
		}
		// Check if hero is dead
		if (eventName == GlobalEventName.EndPhase && GetComponent<EntityData>().health <= 0) {
			DestroyImmediate(gameObject);
		}
	}
}
