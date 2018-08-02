using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGesture : MonoBehaviour {
	public PlayerEvent onInput;
	[Space]
	public CardManager cardManager;

	public void OnEnable() {
		// Drag
		this.BeginDrag(data => {
		});
		this.UpdateDrag(data => {

			transform.position = data.position;
		});
		this.EndDrag(data => {
			print(data.hovered.Count);
			foreach (var item in data.hovered) {
				if (item.GetComponent<CardTarget>()) {
					onInput.Invoke(PlayerAction.Drag, name, item.name);
					break;
				}

			}
		});

		// Card Manager
		cardManager.AddCard(this);
	}
	public void ExecuteEvent(PlayerAction action, string from, string to) {
		// print("execute " + from);
		print(to);
		transform.parent = cardManager.FindArea(to);
	}
	public void OnDisable() {
		// Drag
		this.ClearDrag();

		// Card Manager
		if (cardManager) {
			cardManager.RemoveCard(this);
		}
	}
}
