using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IOnTouch
{
    public GameObject target;
    public string methodName;

    public void OnTouch(GestureState state)
	{
		if (state.phase == GesturePhase.End) {
			target.SendMessage(methodName);
		}
    }
}
