using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicCard : Graphic {
	public TextMesh manaCost;
	public TextMesh attack;
	public TextMesh health;
	public TextMesh title;
	public TextMesh description;

	public override void UpdateGraphics(EntityData entity) {
		manaCost.text = "<b>" + entity.Get("mana_cost") + "</b>";
		attack.text = "<b>" + entity.Get("attack") + "</b>";
		health.text = "<b>" + entity.Get("health") + "</b>";
		title.text = "<b>" + entity.Get("title") + "</b>";
		description.text = "<b>" + entity.Get("description") + "</b>";
	}
}
