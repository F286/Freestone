using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, IOnGlobalEvent {
	public GlobalEventName globalEventName {
		get {
			return GlobalEventName.Any;
		}
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		var player = GetComponentInParent<Player>();

	}
}
