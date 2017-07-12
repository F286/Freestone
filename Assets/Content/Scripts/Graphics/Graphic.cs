using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : MonoBehaviour, IOnTouch {
	public int index;

    public void OnTouch(GestureState state)
	{
        //print(state.phase);
		ManagerGame.instance.TakeAction(state, this);
    }
}
