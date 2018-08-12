using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Card : NetworkBehaviour {
	// public PlayerEvent onIntent;
	// public PlayerEvent onExecute;
	// [Space]
	// public CardManager cardManager;

	[ClientRpc]
	public void RpcSetup(GameObject parent) {
		transform.SetParent(parent.transform, false);
	}

	public override void OnStartAuthority() {
		this.BeginDrag(data => {
		});
		this.UpdateDrag(data => {

			transform.position = data.position;
		});
		this.EndDrag(data => {
			// print(data.hovered.Count);
			foreach (var item in data.hovered) {
				var identity = item.GetComponent<CardTarget>();
				if (identity) {
					print("End drag");
					print("end drag: " + identity.name);
					CmdMoveCard(identity.name);
				}
				// if (item.GetComponent<CardTarget>()) {
				// 	// onIntent.Invoke(IntentType.DragToBoard, name, item.name);
				// 	CmdMoveCard(item);
				// 	break;
				// }

			}
		});
		
		// Drag

		// Card Manager
		// cardManager.AddCard(this);
	}
	// public void Update() {
	// 	print(hasAuthority);
	// }
	[Command]
	public void CmdMoveCard(string target) {
		print("CmdMoveCard: " + target);
		RpcMoveCard(target);
	}
	[ClientRpc]
	public void RpcMoveCard(string target) {
		print("RpcMoveCard: " + target);
		transform.parent = CardManager.instance.FindArea(target);
	}
	// void ExecuteEvent(IntentType action, string from, string to) {
	// 	// print("execute " + from);
	// 	// print(to);
	// 	transform.parent = cardManager.FindArea(to);
	// }
	// public void OnDisable() {
	// 	// onExecute.RemoveListener(ExecuteEvent);
	// 	// Drag
	// 	// this.ClearDrag();

	// 	// Card Manager
	// 	// if (cardManager) {
	// 	// 	cardManager.RemoveCard(this);
	// 	// }
	// }
}
