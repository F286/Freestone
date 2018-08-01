using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public Transform areas;
	public PlayerEvent onIntent;

	Dictionary<string, CardGesture> cards = new Dictionary<string, CardGesture>();

	public void AddCard(CardGesture card) {
		card.onInput.AddListener(Intent);
		cards.Add(card.name, card);
	}
	public void RemoveCard(CardGesture card) {
		card.onInput.RemoveListener(Intent);
		cards.Remove(card.name);
	}
	void Intent(PlayerAction action, string from, string to) {
		onIntent.Invoke(action, from, to);
	}

	public void Execute(PlayerAction action, string from, string to) {
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
