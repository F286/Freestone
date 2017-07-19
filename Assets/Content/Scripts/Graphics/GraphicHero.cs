using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicHero : GraphicMinion {
	public GameObject attackGraphic;
	public TextMesh mana;

	public override void UpdateGraphics(EntityData entity) {
		base.UpdateGraphics(entity);

		mana.text = Format(entity.Get("mana"));

		var a = int.Parse(entity.Get("attack"));
		attack.gameObject.SetActive(a > 0);
		attackGraphic.gameObject.SetActive(a > 0);
	}
}
