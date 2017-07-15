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
public class TRIGGER_OnDragToBoard : MonoBehaviour, ITrigger, IOnInput {
	//public DragEventTarget target

	public void ExternalTrigger() {
		this.TriggerEvent();
	}

	public void OnInput(InputState state) {
		if (transform.parent.name == "hand") {
			//print(state.gesture.phase);
			state.graphic.transform.position = state.gesture.worldPosition;

			if (state.gesture.phase == GesturePhase.End) {
				transform.parent = GetComponentInParent<Player>().board.transform;
				state.manager.OnEndPhase();
			}
		}
	}

}
