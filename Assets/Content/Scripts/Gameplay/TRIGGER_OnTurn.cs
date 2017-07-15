﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState {
	Begin,
	End,
}
public class TRIGGER_OnTurn : MonoBehaviour, ITrigger {
	public TurnState turnState;

	public void ExternalTrigger() {
		this.TriggerEvent();
	}
}