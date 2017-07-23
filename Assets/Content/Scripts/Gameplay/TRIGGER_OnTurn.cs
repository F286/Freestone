using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnState {
	Begin,
	End,
}
public class TRIGGER_OnTurn : MonoBehaviour, ITrigger {
	public PlayerType player = PlayerType.Friendly;
	public TurnState turnState;

}
