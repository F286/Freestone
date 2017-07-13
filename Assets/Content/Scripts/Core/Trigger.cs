﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger {
	
}

public static class TriggerExtensions {

	public static void TriggerEvent(this ITrigger trigger) {
		foreach (var item in (trigger as Component).GetComponents<IAction>()) {
			item.OnEvent();
		}
	}
}