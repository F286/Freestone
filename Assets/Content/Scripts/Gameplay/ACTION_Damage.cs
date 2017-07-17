using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_Damage : MonoBehaviour, IAction {
	public int damage = 1;
	public void OnEvent() {
		var entity = GetComponent<EntityData>();
		var targetPath = entity.Get("target");
		var targetEntity = Core.PathToEntity(targetPath);

		targetEntity.health -= damage;

		ManagerGame.instance.EndPhase();
	}
}
