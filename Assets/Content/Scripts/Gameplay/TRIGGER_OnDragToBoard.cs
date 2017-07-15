using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum DragEventTarget {
//	Character,
//	Minion,
//	Board,
//}
//public enum DragTargetingType {
//	Character,
//	Minion,
//	Board,
//}
public class TRIGGER_OnDragToBoard : MonoBehaviour, ITrigger {
	//public DragEventTarget target;

	public void ExternalTrigger() {
		this.TriggerEvent();
	}
}
