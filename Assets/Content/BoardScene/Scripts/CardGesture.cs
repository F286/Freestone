using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGesture : MonoBehaviour {

	public PlayerEvent onInput;

	[Space]
	public CardManager cardManager;

	public void Start () {

		this.UpdateDrag(data => {

			transform.position = data.position;
		});
		this.EndDrag(data => {
			onInput.Invoke(PlayerAction.Drag, name, "Board (1)");
		});
	}
	public void ExecuteEvent(PlayerAction action, string from, string to) {
		// print("execute " + from);
		print(to);
		transform.parent = cardManager.FindArea(to);
	}

	public void OnEnable() {
		cardManager.AddCard(this);
	}
	public void OnDisable() {
		if (cardManager) {
			cardManager.RemoveCard(this);
		}
	}
}
