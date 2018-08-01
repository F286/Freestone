using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_Destroy : MonoBehaviour, IAction {
	public void OnEvent() {
		Destroy(gameObject);
		gameObject.SetActive(false);
	}
}
