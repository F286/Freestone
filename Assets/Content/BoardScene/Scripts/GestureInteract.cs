using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GestureInteract : MonoBehaviour, IInitializePotentialDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler {

	public bool isDragging = false;
	public PointerEventData cacheEventData;

	public PointerEvent onBegin = new PointerEvent();
	public PointerEvent onUpdate = new PointerEvent();
	public PointerEvent onEnd = new PointerEvent();

  public void OnInitializePotentialDrag(PointerEventData eventData) {
		isDragging = true;
		cacheEventData = eventData;
		eventData.useDragThreshold = false;

		this.GetOrAddComponent<CanvasGroup>().interactable = false;
  }
  public void OnPointerDown(PointerEventData eventData) {
		onBegin.Invoke(eventData);
  }
  public void OnDrag(PointerEventData eventData) {
		cacheEventData = eventData;
  }
  public void OnPointerUp(PointerEventData eventData) {
		cacheEventData = eventData;
		
		isDragging = false;

		onUpdate.Invoke(cacheEventData);
		onEnd.Invoke(cacheEventData);
		
		this.GetOrAddComponent<CanvasGroup>().interactable = true;
  }

	public void Update() {
		if (isDragging) {
			onUpdate.Invoke(cacheEventData);
		}
	}
}
[System.Serializable]
public class PointerEvent : UnityEvent<PointerEventData> {
}