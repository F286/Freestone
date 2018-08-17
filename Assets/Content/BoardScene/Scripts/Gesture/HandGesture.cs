using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGesture : State {

	public override void OnEnter() {
		this.BeginDrag(data => {
		});
		this.UpdateDrag(data => {

			transform.position = data.position;
		});
		this.EndDrag(data => {
			foreach (var item in data.hovered) {
				var identity = item.GetComponent<CardTarget>();
				if (identity) {
					// print("End drag");
					// print("end drag: " + identity.name);
					GetComponent<Card>().CmdMoveCard(identity.name);
				}

			}
		});
	}

	public override void OnExit() {
		this.ClearDrag();
	}
}
