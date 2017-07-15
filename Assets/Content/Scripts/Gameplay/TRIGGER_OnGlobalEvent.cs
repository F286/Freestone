using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGER_OnGlobalEvent : MonoBehaviour, ITrigger {
	public string eventName;

	public void ExternalTrigger() {
		this.TriggerEvent();
	}
}
