using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour, IOnGlobalEvent {
	public void Awake() {
		if (GetComponent<TRIGGER_OnDragToBoard>() == null) {
			gameObject.AddComponent<TRIGGER_OnDragToBoard>();
			gameObject.AddComponent<ACTION_PlayMinion>();
		}
		if (GetComponent<TRIGGER_OnDragToTarget>() == null) {
			gameObject.AddComponent<TRIGGER_OnDragToTarget>();
			gameObject.AddComponent<ACTION_CharacterAttack>();
		}
	}
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
				gameObject.TriggerGlobalEvent(GlobalEventName.OnDeath);
				Destroy(gameObject);
				gameObject.SetActive(false);
			}
		}
	}
}
