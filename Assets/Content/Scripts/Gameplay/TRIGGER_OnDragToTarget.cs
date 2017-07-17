using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGER_OnDragToTarget : MonoBehaviour, ITrigger, IOnInput {
	public bool canTargetHeroes = true;
	public TargetType targetType = TargetType.Enemy;

	public void ExternalTrigger() {
		this.TriggerEvent();
	}

	public void OnInput(InputState state) {
		var entity = GetComponent<EntityData>();
		if (transform.parent.name == "board" && state.graphic != null &&
		    GetComponent<EntityData>().isFriendly && entity.canAttack) {
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
				//print(GameObjectToPath(state.gesture.b));
				entity.Set("target", GameObjectToPath(state.gesture.b));
				this.TriggerEvent();
				state.manager.EndPhase();
			}
		}

	}
	public static string GameObjectToPath(GameObject gameObject) {
		return gameObject.transform.parent.parent.name + "/" + 
			   gameObject.transform.parent.name + "/" +
			   gameObject.transform.name;
	}
	public static GameObject PathToGameObject(string path) {
		return ManagerGame.instance.game.transform.Find(path).gameObject;
	}
}
