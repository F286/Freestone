using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_Modify : MonoBehaviour, IAction {
	public int attack = 1;
	public int health = 1;
	public void OnEvent() {
		var self = GetComponent<EntityData>();
		var target = self.target;

		target.AddEnchantment<ENCHANT_ModifyAttack>().amount = attack;
		target.AddEnchantment<ENCHANT_ModifyHealth>().amount = health;

		ManagerGame.instance.EndPhase();
	}
}
