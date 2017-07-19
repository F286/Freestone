using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGER_OnDeath : MonoBehaviour, ITrigger, IOnGlobalEvent {
	public GlobalEventName globalEventName {
		get {
			return GlobalEventName.OnDeath;
		}
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		this.TriggerEvent();
	}
}