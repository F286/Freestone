using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour {
    public static ManagerGame instance;
    public Event sequence;
    //public List<Character> characters;
    public List<Entity> instances;
    //static Instance empty = new Instance();

    public void Awake() {
        instance = this;
    }
    public void Start() {
        GetComponent<ManagerGraphics>().updateGraphics(instances);
    }
    public void OnEndTurn() {
        print("on end turn");
    }
    public void TakeAction(int a, int b) {
        //var a = instanceA;
        //var b = instanceB;
        //print("a " + a.name);
        //print("b " + b.name);

        //print(a.events.Count);
        var target = instances[a].events.Find(_ => _.target == EventTarget.Minion || 
                                              _.target == EventTarget.Character);

        print(target);

        if(target.type == EventType.Invalid && b != -1) {
            sequence.children.Add(target);
        }
    }
    public void DragCard(GestureState state, Graphic card) {
        if (state.phase == GesturePhase.End) {
            TakeAction(state.a == null ? -1 : state.a.GetComponent<Graphic>().index, 
                       state.b == null ? -1 : state.b.GetComponent<Graphic>().index);
        }
    }
}
