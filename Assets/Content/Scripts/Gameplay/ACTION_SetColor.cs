using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_SetColor : MonoBehaviour, IAction {
	public Camera camera;
	public Color color;
	public void OnEvent() {
		camera.backgroundColor = color;
	}
}
