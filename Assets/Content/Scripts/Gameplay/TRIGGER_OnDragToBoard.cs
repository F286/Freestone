using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGER_OnDragToBoard : MonoBehaviour, ITrigger, IOnInput {

	public void ExternalTrigger() {
		this.TriggerEvent();
	}

	public void OnInput(InputState state) {
		//print("drag to board");
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

				entity.Set("position", targetSiblingIndex.ToString());
				this.TriggerEvent();

				// Battlecry
				var battlecry = GetComponent<TRIGGER_OnBattlecry>();
				if (battlecry == null) {
					state.manager.EndPhase();
				} else {
					state.gesture.setType(GestureType.Battlecry);
					state.manager.EndPhase();
				}
			}
		}
	}

}
