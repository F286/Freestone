using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : MonoBehaviour, IOnTouch {
	public GameObject source;

    public void OnTouch(GestureState state)
	{
        //print(state.phase);
		ManagerGame.instance.DragCard(state, this);
    }
}
