using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
public interface IOnTouch {
    void OnTouch(GestureState state);
}
public class InputManager : MonoBehaviour {
	public GameObject current;
    public void Awake() {
        Input.simulateMouseWithTouches = true;
    }
    public void Update () {
		var phase = GesturePhase.None;

        if (Input.GetMouseButtonDown(0))
        {
            phase = GesturePhase.Begin;
            current = GetOverlap();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			phase = GesturePhase.End;
		}
        else if (Input.GetMouseButton(0)) {
            phase = GesturePhase.Update;
        }

        if (phase != GesturePhase.None && current != null) {
            var state = new GestureState();
			state.phase = phase;
			state.a = current;
			state.b = GetOverlap();
			state.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//print("input " + phase);
			//print("input " + current);
			current.SendMessage("OnTouch", state, SendMessageOptions.DontRequireReceiver);
		}
	}
    GameObject GetOverlap() {
        var o = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.3f);
        if(o != null) {
            return o.gameObject;
        }
        return null;
    }
}
