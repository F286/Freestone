using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour {
    public static ManagerGame instance;
    public Event sequence;
    //public List<Character> characters;
    public List<Card> cards;
    static Card empty = new Card();

    public void Awake() {
        instance = this;
    }
    public void Start() {
        GetComponent<ManagerGraphics>().updateGraphics(cards);
    }
    public void OnEndTurn() {
        print("on end turn");
    }
    public void TakeAction(Card a, Card b) {
        var aEntity = a.entity;
        var bEntity = b.entity;
        print("a " + aEntity.name);
        print("b " + bEntity.name);
    }
    public void DragCard(GestureState state, Graphic card) {
        //print(card.index);
        //print(state.grab);
        //print(state.target);

        if (state.phase == GesturePhase.End)
        {
            TakeAction(GetCard(state.grab), GetCard((state.target)));
            //var grab = cards[state.grab.GetComponent<Graphic>().index];
            //var target = 

            //print(grab);
            //print(target);
        }
    }
    Card GetCard(GameObject grab) {
        if (grab == null) {
            return empty;
        }
        return cards[grab.GetComponent<Graphic>().index];
    }

}
