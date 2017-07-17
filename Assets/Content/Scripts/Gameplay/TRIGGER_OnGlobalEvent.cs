using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GlobalEventName {
	Any,
	BeginTurn,
	EndTurn,
	EndPhase,
	GraphicsBattlecryStart,
	GraphicsBattlecryEnd,
}
public interface IOnGlobalEvent {
	GlobalEventName globalEventName {
		get;
	}
	void OnGlobalEvent(GlobalEventName eventName);
}

public class TRIGGER_OnGlobalEvent : MonoBehaviour, ITrigger, IOnGlobalEvent {
	public GlobalEventName eventName;

	public GlobalEventName globalEventName {
		get {
			return eventName;
		}
	}

	public void ExternalTrigger() {
		this.TriggerEvent();
	}

	public void OnGlobalEvent(GlobalEventName eventName) {
		//print(eventName);
		//print(this);
		this.TriggerEvent();
	}
}

public static class GlobalEventExtensions {
	public static void TriggerGlobalEvent(this GameObject trigger, GlobalEventName eventName) {
		foreach (var item in trigger.GetComponentsInChildren<IOnGlobalEvent>()) {
			if (item.globalEventName == GlobalEventName.Any || eventName == item.globalEventName) {
				item.OnGlobalEvent(eventName);
			}
		}
	}
}