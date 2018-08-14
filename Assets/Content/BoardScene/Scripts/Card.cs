using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Card : NetworkBehaviour {
	[SyncVar(hook = "SetParent")]
	public string parent;
	
	public override void OnStartAuthority() {
		this.BeginDrag(data => {
		});
		this.UpdateDrag(data => {

			transform.position = data.position;
		});
		this.EndDrag(data => {
			foreach (var item in data.hovered) {
				var identity = item.GetComponent<CardTarget>();
				if (identity) {
					print("End drag");
					print("end drag: " + identity.name);
					CmdMoveCard(identity.name);
				}

			}
		});
		
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
	}

}
