using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputState {
	public ManagerGame manager;
	public GestureState gesture;
	public Graphic graphic;

	public InputState(ManagerGame manager, GestureState gesture, Graphic graphic) {
		this.manager = manager;
		this.gesture = gesture;
		this.graphic = graphic;
	}
}
public interface IOnInput {
	void OnInput(InputState state);
}

public class ManagerGame : MonoBehaviour {
    public static ManagerGame instance;
	public ManagerGraphics graphics;
	public GameObject sequence;
	public List<Player> players;
	public GameObject game;
	public Transform arrow;

	public int currentPlayerIndex;

	public Player currentPlayer {
		get {
			return players[currentPlayerIndex];
		}
	}
	public EntityData currentHero {
		get {
			return players[currentPlayerIndex].hero.transform.GetChild(0).GetComponent<EntityData>();
		}
	}

    public void Awake() {
        instance = this;
		arrow.gameObject.SetActive(false);

		for (int i = 0; i < 2; i++) {
			foreach (var item in ManagerData.instance.GetComponentsInChildren<Minion>()) {
				Instantiate(item, players[0].deck.transform);
				Instantiate(item, players[1].deck.transform);
			}
		}
		foreach (var item in ManagerData.instance.GetComponentsInChildren<Spell>()) {
			Instantiate(item, players[0].deck.transform);
			Instantiate(item, players[1].deck.transform);
		}
	}
	public void Start() {
		EndPhase();
		BeginTurn();
		EndPhase();
	}
	public void BeginTurn() {
		game.TriggerGlobalEvent(GlobalEventName.BeginTurn);
	}
	public void EndTurn() {
		game.TriggerGlobalEvent(GlobalEventName.EndTurn);
		EndPhase();
		currentPlayerIndex = (currentPlayerIndex + 1) % 2;

		game.TriggerGlobalEvent(GlobalEventName.BeginTurn);
		EndPhase();
    }
	public void EndPhase() {
		game.TriggerGlobalEvent(GlobalEventName.EndPhase);
		graphics.updateGraphics(this);
	}
    public void DragCard(GestureState state, Graphic graphic) {
		graphic.source.SendMessage("OnInput", new InputState(this, state, graphic), 
		                           SendMessageOptions.DontRequireReceiver);
    }
}
