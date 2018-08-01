using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public Transform areas;
	public PlayerEvent onInput;

	Dictionary<string, CardGesture> cards = new Dictionary<string, CardGesture>();

	public void AddCard(CardGesture card) {
		card.onInput.AddListener(OnInput);
		cards.Add(card.name, card);
	}
	public void RemoveCard(CardGesture card) {
		card.onInput.RemoveListener(OnInput);
		cards.Remove(card.name);
	}
	void OnInput(PlayerAction action, string from, string to) {
		onInput.Invoke(action, from, to);
	}

	public void ExecuteEvent(PlayerAction action, string from, string to) {
		cards[from].ExecuteEvent(action, from, to);
	}

	public Transform FindArea(string areaName) {
		return areas.Find(areaName);
	}

	public static CardManager instance;
	public void OnEnable() {
		instance = this;
	}
}
