using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_CharacterAttack : MonoBehaviour, IAction {
	public void OnEvent() {
		var self = GetComponent<EntityData>();
		var target = self.target;

		self.AddEnchantment<ENCHANT_ModifyHealth>().amount = -target.attack;
		target.AddEnchantment<ENCHANT_ModifyHealth>().amount = -self.attack;

		self.canAttack = false;

		ManagerGame.instance.EndPhase();
	}
}
