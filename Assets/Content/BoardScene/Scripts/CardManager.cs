using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public Transform areas;
	public PlayerEvent onIntent;

	Dictionary<string, Card> cards = new Dictionary<string, Card>();

	public void AddCard(Card card) {
		card.onInput.AddListener(Intent);
		cards.Add(card.name, card);
	}
	public void RemoveCard(Card card) {
		card.onInput.RemoveListener(Intent);
		cards.Remove(card.name);
	}
	void Intent(IntentType action, string from, string to) {
		onIntent.Invoke(action, from, to);
	}

	public void Execute(IntentType action, string from, string to) {
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
