﻿using System;
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
		var entity = GetComponent<EntityData>();
		if (transform.parent.name == "hand" && 
		    GetComponent<EntityData>().isFriendly && 
		    ManagerGame.instance.currentHero.mana >= entity.manaCost) {
			
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

				// Subtract mana cost
				ManagerGame.instance.currentHero.mana -= entity.manaCost;

				state.manager.EndPhase();
			}
		}
	}

}
