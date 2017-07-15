using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType {
	Any,
	Friendly,
	Enemy,
}
public class TRIGGER_OnDragToTarget : MonoBehaviour, ITrigger {
	public bool canTargetHeroes = true;
	public TargetType targetType;

	public void ExternalTrigger() {
		this.TriggerEvent();
	}
}
