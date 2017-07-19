﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrigger : ITriggerAction {
}

public static class TriggerExtensions {

	public static void TriggerEvent(this ITrigger trigger) {
		bool reachedSelf = false;
		foreach (var item in (trigger as Component).GetComponents<ITriggerAction>()) {
			if(item == trigger) {
				reachedSelf = true;
			}
			else if (reachedSelf) {
				if (item is IAction) {
					(item as IAction).OnEvent();
				} else if (item is ITrigger) {
					break;
				}
			}
		}
	}
}