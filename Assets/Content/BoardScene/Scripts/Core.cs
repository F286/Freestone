using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class Core {

	public static Camera menuCamera {
		get {
			var find = GameObject.FindWithTag("MenuCamera");
			if (find) {
				return find.GetComponent<Camera>();
			}
			return null;
		}
	}

	public static T GetOrAddComponent<T>(this MonoBehaviour behaviour) where T : Component {
		var c = behaviour.GetComponent<T>();
		if (c) {
			return c;
		}
		return behaviour.gameObject.AddComponent<T>();
	} 

	public static void BeginDrag(this MonoBehaviour behaviour, UnityAction<PointerEventData> action) {
		behaviour.GetOrAddComponent<GestureInteract>().onBegin.AddListener(action);
	}
	public static void UpdateDrag(this MonoBehaviour behaviour, UnityAction<PointerEventData> action) {
		behaviour.GetOrAddComponent<GestureInteract>().onUpdate.AddListener(action);
	}
	public static void EndDrag(this MonoBehaviour behaviour, UnityAction<PointerEventData> action) {
		behaviour.GetOrAddComponent<GestureInteract>().onEnd.AddListener(action);
	}
	public static void ClearDrag(this MonoBehaviour behaviour) {
		behaviour.GetOrAddComponent<GestureInteract>().onBegin.RemoveAllListeners();
		behaviour.GetOrAddComponent<GestureInteract>().onUpdate.RemoveAllListeners();
		behaviour.GetOrAddComponent<GestureInteract>().onEnd.RemoveAllListeners();
	}

	public static float Dampen(float source, float target, float smoothing) {
		return Mathf.Lerp(source, target, 1 - Mathf.Exp(-smoothing * Time.deltaTime));
	}
}
