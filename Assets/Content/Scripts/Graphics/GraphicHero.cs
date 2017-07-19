using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicHero : GraphicMinion {
	public GameObject attackGraphic;
	public TextMesh mana;

	public override void UpdateGraphics(EntityData entity) {
		base.UpdateGraphics(entity);

		mana.text = "<b>" + entity.mana.ToString() + "</b>";

		var a = entity.attack;
		attack.gameObject.SetActive(a > 0);
		attackGraphic.gameObject.SetActive(a > 0);
	}
}
