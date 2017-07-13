using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : MonoBehaviour, IAction {
	public void OnEvent() {
		print("attack");
	}
}
