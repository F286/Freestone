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
    public Graphic a;
    public Graphic b;
	public Vector2 worldPosition;
	public GestureType type;
	public System.Action<GestureType> setType;
}
public interface IOnTouch {
    void OnTouch(GestureState state);
}
public class InputManager : MonoBehaviour {
	public EntityData current;
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
				var overlap = GetOverlap();
				current = overlap == null ? null : overlap.GetComponent<Graphic>().source.GetComponent<EntityData>();
			} else if (Input.GetMouseButtonUp(0)) {
				phase = GesturePhase.End;
			} else if (Input.GetMouseButton(0)) {
				phase = GesturePhase.Update;
			}
			break;

			case GestureType.Battlecry:
			phase = GesturePhase.Update;
			if (Input.GetMouseButtonUp(0)) {
				phase = GesturePhase.End;
			}
			break;
		}
		if (phase != GesturePhase.None && current != null) {
			//print("start " + current);
            var state = new GestureState();
			state.phase = phase;
			var path = Core.GameObjectToPath(current.gameObject);
			var graphic = Core.PathToGraphic(path);
			//print(path);
			//print(graphic);
			state.a = graphic;
			var overlap = GetOverlap();
			state.b = overlap == null ? null : overlap.GetComponent<Graphic>();
			state.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			state.type = type;
			state.setType = SetGestureType;
			//print(current);
			graphic.SendMessage("OnTouch", state, SendMessageOptions.DontRequireReceiver);

			//print(current);
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
