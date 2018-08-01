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
	public GameObject dragBegin;
	public EntityData entity;
	public GestureType type;
	bool wasBattlecry = false;

    public void Awake() {
        Input.simulateMouseWithTouches = true;
    }
    public void Update () {
		var phase = GesturePhase.None;

		switch (type) {
			
			case GestureType.Drag:
			wasBattlecry = false;
			if (Input.GetMouseButtonDown(0)) {
				phase = GesturePhase.Begin;
				var overlap = GetOverlap();
				dragBegin = overlap;

				var g = overlap == null ? null : overlap.GetComponent<Graphic>();
				entity = g == null ? null : g.source.GetComponent<EntityData>();

				if (overlap == null) {
					phase = GesturePhase.None;
				}
			} else if (Input.GetMouseButtonUp(0)) {
				phase = GesturePhase.End;
			} else if (Input.GetMouseButton(0)) {
				phase = GesturePhase.Update;
			}
			break;

			case GestureType.Battlecry:
			phase = wasBattlecry ? GesturePhase.Update : GesturePhase.Begin;
			wasBattlecry = true;
			if (Input.GetMouseButtonUp(0)) {
				phase = GesturePhase.End;
			}
			break;
		}
		if (phase != GesturePhase.None) {
			var graphic = dragBegin;
			if (type == GestureType.Battlecry) {
				graphic = Core.PathToGraphic(Core.GameObjectToPath(entity.gameObject)).gameObject;
			}
			if (graphic != null) { 
				var state = new GestureState();
				state.phase = phase;

				state.a = graphic;
				state.b = GetOverlap();
				state.worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				state.type = type;
				state.setType = SetGestureType;
				//print(graphic);
				graphic.SendMessage("OnTouch", state, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	void SetGestureType(GestureType gestureType) {
		type = gestureType;

		if(gestureType == GestureType.Battlecry) {
			gameObject.TriggerGlobalEvent(GlobalEventName.GraphicsBattlecryStart);
		}
		else if (gestureType == GestureType.Drag) {
			gameObject.TriggerGlobalEvent(GlobalEventName.GraphicsBattlecryEnd);
		}
	}
    GameObject GetOverlap() {
        var o = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.03f);
        if(o != null) {
            return o.gameObject;
        }
        return null;
    }
}
