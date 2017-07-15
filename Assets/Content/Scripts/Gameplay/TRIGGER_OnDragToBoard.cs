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
		if (transform.parent.name == "hand" && GetComponent<EntityData>().isFriendly) {
			//print(state.gesture.phase);
			state.graphic.transform.position = state.gesture.worldPosition;

			if (state.gesture.phase == GesturePhase.End) {
				var player = GetComponentInParent<Player>();

				// Calculate target sibling index
				int targetSiblingIndex = 0;
				foreach (Transform item in player.graphicBoard.transform) {
					if(item.position.x > state.gesture.worldPosition.x) {
						break;
					}
					targetSiblingIndex++;
				}
				// Set parent and sibling index
				transform.parent = player.board.transform;
				transform.SetSiblingIndex(targetSiblingIndex);

				// make easier way to access hero ect.. probably this stuff shouldn't be stored as strings.
				//this stuff should be in ACTION_PlayMinion?
				//GetComponentInParent<Player>().
				var entity = GetComponent<EntityData>();
				//print(entity.player.GetComponent<EntityData>());
				entity.player.hero.transform.GetChild(0).GetComponent<EntityData>().mana -= entity.manaCost;

				state.manager.EndPhase();
			}
		}
	}

}
