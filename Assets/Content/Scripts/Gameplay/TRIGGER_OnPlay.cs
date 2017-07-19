using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGER_OnPlay : MonoBehaviour, ITrigger, IOnGlobalEvent {
	public GlobalEventName globalEventName {
		get {
			return GlobalEventName.OnPlay;
		}
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		this.TriggerEvent();
	}
}