using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnLocation {
	Left,
	Right,
	Board,
    Hand,
    Deck,
}
public class ACTION_Spawn : MonoBehaviour, IAction {
	public string minionName;
	public SpawnLocation location = SpawnLocation.Right;
	public static int index;
	public void OnEvent() {
		Transform t = null;
		switch (location) {
			case SpawnLocation.Left:
			t = transform.parent;
			break;
			case SpawnLocation.Right:
			t = transform.parent;
			break;
			case SpawnLocation.Board:
			t = GetComponentInParent<Player>().board.transform;
			break;
			case SpawnLocation.Hand:
			t = GetComponentInParent<Player>().hand.transform;
			break;
			case SpawnLocation.Deck:
			t = GetComponentInParent<Player>().deck.transform;
			break;
		}
		var n = minionName == "" ? name : minionName;
		var entity = ManagerData.instance.GetEntity(n);
		var g = Instantiate(entity, t);
		g.name = n + index;
		if (location == SpawnLocation.Left) {
			g.transform.SetSiblingIndex(transform.GetSiblingIndex());
		}
		else if (location == SpawnLocation.Right) {
			g.transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
		}

		index++;
	}
}
