﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGraphics : MonoBehaviour {

	public List<Graphic> graphics;
	public List<Arc> boards;
	public List<Arc> hands;

	public void updateGraphics(ManagerGame game) {
		// Destroy previous graphics
		for (int i = 0; i < 2; i++) {
			DestoryAllChildren(game.players[i].graphicHand);
			DestoryAllChildren(game.players[i].graphicBoard);
			DestoryAllChildren(game.players[i].graphicDeck);
		}

		// Iterate over each controller
		for (int controllerIndex = 0; controllerIndex < 2; controllerIndex++) {
			// Add all cards to hand
			var hand = game.players[controllerIndex].hand.transform;

			for (int i = 0; i < hand.childCount; i++) {
				var item = hand.GetChild(i);
				var t = 0.5f;
				if (hand.childCount > 1) {
					t += i * (1f / 6f);
					t -= ((hand.childCount - 1f) / 6f) / 2f;
				}
				var position = hands[controllerIndex].evaluate(t);
				var tr = game.players[controllerIndex].graphicHand.transform;
				var graphic = Instantiate(Resources.Load("Prefab Card") as GameObject, position, Quaternion.identity, tr);
				graphic.GetComponent<GraphicCard>().source = item.gameObject;
				graphic.GetComponent<Graphic>().UpdateGraphics(item.GetComponent<EntityData>());
			}
			// Add all minions to board
			var board = game.players[controllerIndex].board.transform;

			for (int i = 0; i < board.childCount; i++) {
				var item = board.GetChild(i);
				var t = 0.5f;
				if (board.childCount > 1) {
					t += i * (1f / 6f);
					t -= ((board.childCount - 1f) / 6f) / 2f;
				}
				var position = boards[controllerIndex].evaluate(t);
				var tr = game.players[controllerIndex].graphicBoard.transform;
				var graphic = Instantiate(Resources.Load("Prefab Minion") as GameObject, position, Quaternion.identity, tr);
				graphic.GetComponent<GraphicMinion>().source = item.gameObject;
				graphic.GetComponent<Graphic>().UpdateGraphics(item.GetComponent<EntityData>());
			}
		}

	}

	void DestoryAllChildren(GameObject g) {
		var t = g.transform;
		for (int i = t.childCount - 1; i >= 0; i--) {
			DestroyImmediate(t.GetChild(i).gameObject);
		}
	}
}
