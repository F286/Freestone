using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Graphic : MonoBehaviour, IOnTouch {
	public GameObject source;

    public void OnTouch(GestureState state)
	{
        //print(state.phase);
		ManagerGame.instance.DragCard(state, this);
    }
	public abstract void UpdateGraphics(EntityData entity);

	public static string Format(string text) {
		return "<b>" + text.Replace('/', '\n') + "</b>";
	}
}
