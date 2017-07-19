using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_SwapHealth : MonoBehaviour, IAction {
	public int damage = 1;
	public void OnEvent() {
		var self = GetComponent<EntityData>();
		var target = Core.PathToEntity(self.Get("target"));

		var s = self.health;
		var t = target.health;
		self.health = t;
		target.health = s;

		ManagerGame.instance.EndPhase();
	}
}
