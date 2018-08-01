using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGesture : MonoBehaviour {

	public PlayerEvent onInput;

	public void Start () {

		this.UpdateDrag(data => {

			transform.position = data.position;
		});
		this.EndDrag(data => {
			onInput.Invoke(PlayerAction.Drag, transform.name, "other");
		});
	}

	public void OnEnable() {
		GetComponentInParent<CardManager>().AddCard(this);
	}
	public void OnDisable() {
		var parent = GetComponentInParent<CardManager>();
		if (parent) {
			parent.RemoveCard(this);
		}
	}
}
