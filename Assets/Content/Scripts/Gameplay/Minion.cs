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
		if(eventName == GlobalEventName.BeginTurn && 
		   transform.parent.name == "board" &&
		   GetComponentInParent<Player>().number == ManagerGame.instance.currentPlayerIndex) {

			GetComponent<EntityData>().canAttack = true;
		}
	}
}
