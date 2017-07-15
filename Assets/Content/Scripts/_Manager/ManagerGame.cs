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
	public GameObject sequence;
	public List<Player> players;
	public GameObject game;

	public int currentPlayer;

    public void Awake() {
        instance = this;
    }
    public void Start() {

		BeginTurn();
		EndPhase();
	}
	public void BeginTurn() {
		game.TriggerGlobalEvent(GlobalEventName.BeginTurn);
	}
	public void EndTurn() {
		game.TriggerGlobalEvent(GlobalEventName.EndTurn);
		EndPhase();
		currentPlayer = (currentPlayer + 1) % 2;

		game.TriggerGlobalEvent(GlobalEventName.BeginTurn);
		EndPhase();
    }
	public void EndPhase() {
		GetComponent<ManagerGraphics>().updateGraphics(this);
	}
    public void DragCard(GestureState state, Graphic graphic) {
		graphic.source.SendMessage("OnInput", new InputState(this, state, graphic), 
		                           SendMessageOptions.DontRequireReceiver);
    }
}
