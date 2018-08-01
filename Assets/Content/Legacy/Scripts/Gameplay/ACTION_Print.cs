using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_Print : MonoBehaviour, IAction {
	public string message;
	public void OnEvent() {
		Debug.Log("<b>" + message + "</b>");
	}
}
