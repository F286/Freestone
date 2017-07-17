using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_PlaySpell : MonoBehaviour, IAction {
	public void OnEvent() {
		var entity = GetComponent<EntityData>();
		// Subtract mana cost
		ManagerGame.instance.currentHero.mana -= entity.manaCost;

		Destroy(gameObject);
		gameObject.SetActive(false);
	}
}
