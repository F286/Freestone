using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour, IOnGlobalEvent {
	public GlobalEventName globalEventName {
		get {
			return GlobalEventName.Any;
		}
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		if (transform.parent.name == "board") {
			if (eventName == GlobalEventName.BeginTurn &&
			   GetComponentInParent<Player>().number == ManagerGame.instance.currentPlayerIndex) {

				GetComponent<EntityData>().canAttack = true;
			}
			if (eventName == GlobalEventName.EndPhase && GetComponent<EntityData>().health <= 0) {
				Destroy(gameObject);
				gameObject.SetActive(false);
			}
		}
	}
}
