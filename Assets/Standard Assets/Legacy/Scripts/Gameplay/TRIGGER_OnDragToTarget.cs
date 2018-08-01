using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Location {
//	board,
//	hand,
//}
public enum DragToTargetType {
	minion,
	spell,
}

public class TRIGGER_OnDragToTarget : MonoBehaviour, ITrigger, IOnInput {
	public DragToTargetType type;
	public bool canTargetHeroes = true;
	public PlayerType targetType = PlayerType.Enemy;

	public void OnInput(InputState state) {
		var entity = GetComponent<EntityData>();
		var isValid = state.graphic != null && GetComponent<EntityData>().isFriendly;
		if (type == DragToTargetType.minion) {
			isValid = isValid && transform.parent.name == "board" && entity.canAttack;
		} else if (type == DragToTargetType.spell) {
			isValid = isValid && transform.parent.name == "hand" && entity.manaCost <= ManagerGame.instance.currentHero.mana;
		}
		if (isValid) {
			// Arrow
			var spriteRenderer = ManagerGame.instance.arrow.GetComponent<SpriteRenderer>();
			if(state.gesture.phase == GesturePhase.Begin) {
				ManagerGame.instance.arrow.gameObject.SetActive(true);
			}
			else if (state.gesture.phase == GesturePhase.End) {
				ManagerGame.instance.arrow.gameObject.SetActive(false);
			}
			var a = (Vector2)state.graphic.transform.position;
			var b = state.gesture.worldPosition;
			var diff = b - a;

			ManagerGame.instance.arrow.position = a;
			ManagerGame.instance.arrow.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(diff.y, diff.x)
			                                                       * (360f / (Mathf.PI * 2)));
			spriteRenderer.size = new Vector2(diff.magnitude / spriteRenderer.transform.localScale.y, 
			                                  spriteRenderer.size.y);
			
			if (state.gesture.b != null && state.gesture.phase == GesturePhase.End) {
				entity.targetGraphic = state.gesture.b;
				this.TriggerEvent();
				state.manager.EndPhase();

			}
		}

	}

}
