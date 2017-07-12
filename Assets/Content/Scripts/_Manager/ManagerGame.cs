using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour {
    public static ManagerGame instance;
    public Event sequence;
    //public List<Character> characters;
    public List<Card> cards;

    public void Awake() {
        instance = this;
    }
    public void Start() {
        GetComponent<ManagerGraphics>().updateGraphics(cards);
    }
    public void OnEndTurn() {
        print("on end turn");
    }
    public void TakeAction(GestureState state, Graphic card) {
		//print(card.index);
		print(state.grab);
		print(state.overlap);
    }

}
