﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGER_OnDrawCard : MonoBehaviour, ITrigger {

	public void ExternalTrigger() {
		this.TriggerEvent();
	}
}