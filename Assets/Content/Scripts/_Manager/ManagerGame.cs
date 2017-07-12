using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour {
    public static ManagerGame instance;
    public Event sequence;
    //public List<Character> characters;
    public List<Instance> cards;
    static Instance empty = new Instance();

    public void Awake() {
        instance = this;
    }
    public void Start() {
        GetComponent<ManagerGraphics>().updateGraphics(cards);
    }
    public void OnEndTurn() {
        print("on end turn");
    }
    public void TakeAction(Instance instanceA, Instance instanceB) {
        var a = instanceA.entity;
        var b = instanceB.entity;
        print("a " + a.name);
        print("b " + b.name);

        //print(a.events.Count);
        var target = a.events.Find(_ => _.target == EventTarget.Minion 
                                   || _.target == EventTarget.Character);

        print(target);

        if(target.type == EventType.Invalid && b.type != EntityType.Invalid) {
            sequence.children.Add(target);
        }
    }
    public void DragCard(GestureState state, Graphic card) {
        //print(card.index);
        //print(state.grab);
        //print(state.target);

        if (state.phase == GesturePhase.End)
        {
            TakeAction(GetInstance(state.grab), GetInstance((state.target)));
            //var grab = cards[state.grab.GetComponent<Graphic>().index];
            //var target = 

            //print(grab);
            //print(target);
        }
    }
    Instance GetInstance(GameObject grab) {
        if (grab == null) {
            return empty;
        }
        return cards[grab.GetComponent<Graphic>().index];
    }

}
