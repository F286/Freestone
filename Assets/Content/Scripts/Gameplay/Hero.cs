﻿using System;
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
		if(eventName == GlobalEventName.BeginTurn && 
		   GetComponentInParent<Player>().number == ManagerGame.instance.currentPlayerIndex) {
			var entity = GetComponent<EntityData>();

			entity.maxMana = Math.Min(entity.maxMana + 1, 10);
			entity.mana = entity.maxMana;
		}
	}
}
