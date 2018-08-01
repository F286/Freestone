using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public PlayerEvent onInput;

	public void AddCard(CardGesture card) {
		card.onInput.AddListener(OnInput);
	}
	public void RemoveCard(CardGesture card) {
		card.onInput.RemoveListener(OnInput);
	}
	void OnInput(PlayerAction action, string from, string to) {
		print("card manager");
		onInput.Invoke(action, from, to);
	}

	public void ExecuteEvent(PlayerAction action, string from, string to) {
	}

	public static CardManager instance;
	public void OnEnable() {
		instance = this;
	}
}
