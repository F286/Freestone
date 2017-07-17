using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GestureType {
	Drag,
	Battlecry,
}
public enum GesturePhase {
    Begin,
    Update,
    End,
    None,
}
public struct GestureState {
    public GesturePhase phase;
    public GameObject a;
    public GameObject b;
	public Vector2 worldPosition;
	public GestureType type;
	public System.Action<GestureType> setType;
}
public interface IOnTouch {
    void OnTouch(GestureState state);
}
public class InputManager : MonoBehaviour {
	public GameObject current;
	//public GameObject current;
	//public Transform battlecry;
	public GestureType type;

    public void Awake() {
        Input.simulateMouseWithTouches = true;
    }
    public void Update () {
		var phase = GesturePhase.None;

		switch (type) {
			case GestureType.Drag:

			if (Input.GetMouseButtonDown(0)) {
				phase = GesturePhase.Begin;
				current = GetOverlap();
				//print("set");
				//battlecry = current.transform;
			} else if (Input.GetMouseButtonUp(0)) {
				phase = GesturePhase.End;
			} else if (Input.GetMouseButton(0)) {
				phase = GesturePhase.Update;
			}

			break;
			case GestureType.Battlecry:

			//print(current);
			//if (phase == GesturePhase.End) {
			//	phase = GesturePhase.Begin;
			//} else if (phase == GesturePhase.Begin) {
			//	phase = GesturePhase.Update;
			//}
			phase = GesturePhase.Update;
			if (Input.GetMouseButtonUp(0)) {
				phase = GesturePhase.End;
			}

			break;
		}

		//print(battlecry);
		//print("type " + type + "   phase " + phase + "   current " + current);
		if (phase != GesturePhase.None && current != null) {

			print("start " + current);
            var state = new GestureState();
			state.phase = phase;
			state.a = current;
			state.b = GetOverlap();
			state.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			state.type = type;
			state.setType = SetGestureType;
			current.SendMessage("OnTouch", state, SendMessageOptions.DontRequireReceiver);

			print(current);
		}
	}
	void SetGestureType(GestureType gestureType) {
		type = gestureType;
	}
    GameObject GetOverlap() {
        var o = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.3f);
        if(o != null) {
            return o.gameObject;
        }
        return null;
    }
}
