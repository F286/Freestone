﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

	public int requiredForStart = 2;

	public Transform areas;
	public Transform[] hands;
	public GameObject cardTemplate;
	// public PlayerEvent onIntent;
	// public PlayerEvent onExecute;

	Dictionary<string, Card> cards = new Dictionary<string, Card>();

	public void AddCard(Card card) {
		// card.onIntent.AddListener(Intent);
		cards.Add(card.name, card);
	}
	public void RemoveCard(Card card) {
		// card.onIntent.RemoveListener(Intent);
		cards.Remove(card.name);
	}
	// void Intent(IntentType action, string from, string to) {
	// 	Debug.Log(string.Format("<b>Intent </b>action: {0}  from: {1}  to: {2}", action, from, to));
	// 	onIntent.Invoke(action, from, to);
	// }

	// void Execute(IntentType action, string from, string to) {
	// 	Debug.Log(string.Format("<b>Execute </b>action: {0}  from: {1}  to: {2}", action, from, to));
	// 	// cards[from].onExecute.Invoke(action, from, to);
	// 	// cards[from].ExecuteEvent(action, from, to);
	// }

	public Transform FindArea(string areaName) {
		return areas.Find(areaName);
	}

	static CardManager _instance;
	public static CardManager instance {
		get {
			if (!_instance) {
				_instance = GameObject.FindObjectOfType<CardManager>();
			}
			return _instance;
		}
	}
	// public void OnEnable() {
	// 	instance = this;
	// 	// onExecute.AddListener(Execute);
	// }
	// public void OnDisable() {
	// 	onExecute.RemoveListener(Execute);
	// }
}
