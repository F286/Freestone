﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState {
	Begin,
	End,
}
public class TRIGGER_OnTurn : MonoBehaviour, ITrigger, IOnGlobalEvent {
	public PlayerType player = PlayerType.Friendly;
	public TurnState turnState;

	public GlobalEventName globalEventName {
		get {
			return GlobalEventName.Any;
		}
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		if (turnState == TurnState.Begin && eventName == GlobalEventName.BeginTurn ||
		    turnState == TurnState.End && eventName == GlobalEventName.EndTurn) {
			if (this.GetLocation() == CardLocation.Board) {
				if (this.GetPlayer() == ManagerGame.instance.currentPlayer) {
					this.TriggerEvent();
				}
			}
		}
	}
}
