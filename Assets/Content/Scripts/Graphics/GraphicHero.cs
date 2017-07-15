using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicHero : GraphicMinion {
	public GameObject attackGraphic;

	public override void UpdateGraphics(EntityData entity) {
		attack.text = Format(entity.Get("attack"));
		health.text = Format(entity.Get("health"));

		var a = int.Parse(entity.Get("attack"));
		attack.gameObject.SetActive(a > 0);
		attackGraphic.gameObject.SetActive(a > 0);
	}
}
