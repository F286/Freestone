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

	void DrawCard() {
		var player = this.GetPlayer();
		// Draw card
		if (player.deck.transform.childCount > 0) {
			var randomChild = UnityEngine.Random.Range(0, player.deck.transform.childCount - 1);
			player.deck.transform.GetChild(randomChild).SetParent(player.hand.transform);
		}
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		var player = this.GetPlayer();
		if (eventName == GlobalEventName.BeginGame) {
			for (int i = 0; i < 2; i++) {
				DrawCard();
			}
		}
		// Start of Turn
		if (eventName == GlobalEventName.BeginTurn && 
		    player.number == ManagerGame.instance.currentPlayerIndex) {
			
			var entity = GetComponent<EntityData>();

			// Increase mana
			entity.maxMana = Math.Min(entity.maxMana + 1, 10);
			entity.mana = entity.maxMana;

			DrawCard();
		}
		// Check if hero is dead
		if (eventName == GlobalEventName.EndPhase && GetComponent<EntityData>().health <= 0) {
			Destroy(gameObject);
			gameObject.SetActive(false);
		}
	}
}
