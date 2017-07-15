using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_CharacterAttack : MonoBehaviour, IAction {
	public void OnEvent() {
		print("attack");
	}
}
