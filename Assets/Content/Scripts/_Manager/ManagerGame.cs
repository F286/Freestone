using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour {
    public static ManagerGame instance;
	//public List<Event> sequence;
	public GameObject sequence;
	public List<GameObject> hands;
	public List<GameObject> boards;
	public List<GameObject> decks;
    //public List<Entity> instances;

    public void Awake() {
        instance = this;
    }
    public void Start() {
        GetComponent<ManagerGraphics>().updateGraphics(this);
    }
    public void OnEndTurn() {
        print("on end turn");
    }
    public void TakeAction(int a, int b) {
		if (a == b) {
			return;
		}
  //      var targetable = instances[a].events.Find(_ => _.target == EventTarget.Minion || 
  //                                            _.target == EventTarget.Character);

		//print(targetable);
		//print(b);
   //     if(targetable.type != EventType.Invalid && b != -1) {
			//var c = targetable.clone();
			//c.a = a;
			//c.b = b;
        //    sequence.Add(c);
        //}
    }
    public void DragCard(GestureState state, Graphic card) {
        if (state.phase == GesturePhase.End) {
            //TakeAction(state.a == null ? -1 : state.a.GetComponent<Graphic>().index, 
                       //state.b == null ? -1 : state.b.GetComponent<Graphic>().index);
        }
    }
}
