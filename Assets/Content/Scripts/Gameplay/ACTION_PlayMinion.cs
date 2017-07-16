using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_PlayMinion : MonoBehaviour, IAction {
	public void OnEvent() {
		var player = GetComponentInParent<Player>();

		var entity = GetComponent<EntityData>();
		var targetSiblingIndex = int.Parse(entity.Get("position"));

		// Set parent and sibling index
		transform.parent = player.board.transform;
		transform.SetSiblingIndex(targetSiblingIndex);

		// Subtract mana cost
		ManagerGame.instance.currentHero.mana -= entity.manaCost;
	}
}
