using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGraphics : MonoBehaviour {

	public List<Graphic> graphics;
	public List<Arc> boards;
	public List<Arc> hands;

	public void updateGraphics(ManagerGame game) {
		// Destroy all children
		for (int i = transform.childCount - 1; i >= 0; i--) {
			DestroyImmediate(transform.GetChild(i).gameObject);
		}
		//foreach (Transform child in transform) {
		//	Destroy(child.gameObject);
		//}
		//transform.DetachChildren();

		// Iterate over each controller
		for (int controllerIndex = 0; controllerIndex < 2; controllerIndex++) {
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
				var card = Instantiate(Resources.Load("Prefab Minion"), position, Quaternion.identity, transform);
				(card as GameObject).GetComponent<GraphicMinion>().source = item.gameObject;
			}

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
				var card = Instantiate(Resources.Load("Prefab Card"), position, Quaternion.identity, transform);
				(card as GameObject).GetComponent<GraphicCard>().source = item.gameObject;
			}
		}

	}
}
