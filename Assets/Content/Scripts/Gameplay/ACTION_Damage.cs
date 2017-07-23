using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_Damage : MonoBehaviour, IAction {
	public int damage = 1;
	public void OnEvent() {
		var self = GetComponent<EntityData>();
		var target = Core.PathToEntity(self.Get("target"));

		target.AddEnchantment<ENCHANT_ModifyHealth>().amount = -damage;

		ManagerGame.instance.EndPhase();
	}
}
