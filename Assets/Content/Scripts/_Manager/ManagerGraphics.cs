using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGraphics : MonoBehaviour {

	public static ManagerGraphics instance;

	public List<Graphic> graphics;
	public List<Arc> boards;
	public List<Arc> hands;
	public List<Arc> heroes;

	public void Awake() {
		instance = this;
	}

	public void updateGraphics(ManagerGame game) {
		// Destroy previous graphics
		for (int i = 0; i < 2; i++) {
			DestroyAllChildren(game.players[i].graphicHand);
			DestroyAllChildren(game.players[i].graphicBoard);
			DestroyAllChildren(game.players[i].graphicDeck);
			DestroyAllChildren(game.players[i].graphicHero);
		}

		// Iterate over each controller
		for (int controllerIndex = 0; controllerIndex < 2; controllerIndex++) {
			UnparentDisabledChildren(game.players[controllerIndex].hand);
			UnparentDisabledChildren(game.players[controllerIndex].board);
			UnparentDisabledChildren(game.players[controllerIndex].hero);
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
				graphic.name = item.name;
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
				graphic.name = item.name;
				graphic.GetComponent<GraphicMinion>().source = item.gameObject;
				graphic.GetComponent<Graphic>().UpdateGraphics(item.GetComponent<EntityData>());
			}
			// Add hero
			if (game.players[controllerIndex].hero.transform.childCount > 0)
			{
				var item = game.players[controllerIndex].hero.transform.GetChild(0);
				var t = 0.5f;
				var position = heroes[controllerIndex].evaluate(t);
				var tr = game.players[controllerIndex].graphicHero.transform;
				var graphic = Instantiate(Resources.Load("Prefab Hero") as GameObject, position, Quaternion.identity, tr);
				graphic.name = item.name;
				graphic.GetComponent<GraphicMinion>().source = item.gameObject;
				graphic.GetComponent<Graphic>().UpdateGraphics(item.GetComponent<EntityData>());
			}

		}

	}

	void DestroyAllChildren(GameObject g) {
		var t = g.transform;
		for (int i = t.childCount - 1; i >= 0; i--) {
			DestroyImmediate(t.GetChild(i).gameObject);
		}
	}
	void UnparentDisabledChildren(GameObject g) {
		var t = g.transform;
		for (int i = t.childCount - 1; i >= 0; i--) {
			if (t.GetChild(i).gameObject.activeSelf == false) {
				t.GetChild(i).parent = null;
			}
		}
	}
}
