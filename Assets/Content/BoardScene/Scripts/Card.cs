using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Card : NetworkBehaviour {
	[SyncVar(hook = "SetParent")]
	public string parent;

	public StateMachine gesture;
	public State hand;
	public State board;
	
	public override void OnStartAuthority() {
		SetupGestures();
	}

	void SetupGestures() {
		gesture.Set(hand);
	}

	[Command]
	public void CmdMoveCard(string target) {
		print("CmdMoveCard: " + target);
		parent = target;
	}

	public void Start() {
		if (!string.IsNullOrEmpty(parent)) {
			SetParentLocal(parent);
		}
	}

	public void SetParent(string setParent) {
		SetParentLocal(setParent);
	}

	void SetParentLocal(string setParent) {
		transform.SetParent(CardManager.instance.FindArea(setParent), false);

		print("hasAuthority " + hasAuthority);
		if (hasAuthority) {
			if (setParent.Contains("Hand")) {
				gesture.Set(hand);
			}
			else {
				gesture.Set(board);
			}
		}
	}

}
