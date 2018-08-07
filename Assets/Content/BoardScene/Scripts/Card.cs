using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	public PlayerEvent onIntent;
	public PlayerEvent onExecute;
	[Space]
	public CardManager cardManager;

	public void OnEnable() {
		onExecute.AddListener(ExecuteEvent);

		// Drag
		this.BeginDrag(data => {
		});
		this.UpdateDrag(data => {

			transform.position = data.position;
		});
		this.EndDrag(data => {
			// print(data.hovered.Count);
			foreach (var item in data.hovered) {
				if (item.GetComponent<CardTarget>()) {
					onIntent.Invoke(IntentType.DragToBoard, name, item.name);
					break;
				}

			}
		});

		// Card Manager
		cardManager.AddCard(this);
	}
	void ExecuteEvent(IntentType action, string from, string to) {
		// print("execute " + from);
		// print(to);
		transform.parent = cardManager.FindArea(to);
	}
	public void OnDisable() {
		onExecute.RemoveListener(ExecuteEvent);
		// Drag
		this.ClearDrag();

		// Card Manager
		if (cardManager) {
			cardManager.RemoveCard(this);
		}
	}
}
