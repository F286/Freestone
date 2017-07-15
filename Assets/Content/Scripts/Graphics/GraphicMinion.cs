using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicMinion : Graphic {
	public TextMesh attack;
	public TextMesh health;

	public override void UpdateGraphics(EntityData entity) {
		attack.text = "<b>" + entity.Get("attack") + "</b>";
		health.text = "<b>" + entity.Get("health") + "</b>";
	}
}
