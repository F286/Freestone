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

    public void Awake() {
        instance = this;
    }
    public void Start() {
        GetComponent<ManagerGraphics>().updateGraphics(this);
    }
    public void OnEndTurn() {
        print("on end turn");
    }
	public void OnEndPhase() {
		GetComponent<ManagerGraphics>().updateGraphics(this);
	}
  //  public void TakeAction(int a, int b) {
		//if (a == b) {
		//	return;
		//}
  ////      var targetable = instances[a].events.Find(_ => _.target == EventTarget.Minion || 
  ////                                            _.target == EventTarget.Character);

		////print(targetable);
		////print(b);
   ////     if(targetable.type != EventType.Invalid && b != -1) {
			////var c = targetable.clone();
			////c.a = a;
			////c.b = b;
    //    //    sequence.Add(c);
    //    //}
    //}
    public void DragCard(GestureState state, Graphic graphic) {
		graphic.source.SendMessage("OnInput", new InputState(this, state, graphic), 
		                           SendMessageOptions.DontRequireReceiver);
        //if (state.phase == GesturePhase.End) {
        //    //TakeAction(state.a == null ? -1 : state.a.GetComponent<Graphic>().index, 
        //               //state.b == null ? -1 : state.b.GetComponent<Graphic>().index);
        //}
    }
}
