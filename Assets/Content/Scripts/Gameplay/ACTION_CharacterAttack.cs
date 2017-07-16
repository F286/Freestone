using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_CharacterAttack : MonoBehaviour, IAction {
	public void OnEvent() {
		var entity = GetComponent<EntityData>();
		var targetPath = entity.Get("target");
		var target = TRIGGER_OnDragToTarget.PathToGameObject(targetPath);

		var targetEntity = target.GetComponent<EntityData>();

		entity.health -= targetEntity.attack;
		targetEntity.health -= entity.attack;

		entity.canAttack = false;
	}
}
