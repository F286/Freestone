using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Graphic : MonoBehaviour, IOnTouch {
	public GameObject source;
	public TextMesh attack;
	public TextMesh health;

    public void OnTouch(GestureState state)
	{
        //print(state.phase);
		ManagerGame.instance.DragCard(state, this);
    }
	public virtual void UpdateGraphics(EntityData entity) {
		attack.text = Format(entity.attack.ToString());
		health.text = Format(entity.health.ToString());
	}

	public static string Format(string text) {
		return "<b>" + text.Replace('/', '\n') + "</b>";
	}
}
