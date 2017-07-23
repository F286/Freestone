using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicCard : Graphic {
	public TextMesh manaCost;
	public TextMesh title;
	public TextMesh description;

	public GameObject attackCircle;
	public GameObject healthCircle;

	public override void UpdateGraphics(EntityData entity) {
		base.UpdateGraphics(entity);

		manaCost.text = 	Core.Format(entity.Get("mana_cost") 	);
		title.text = 		Core.Format(entity.Get("title") 		);
		description.text = 	Core.Format(entity.Get("description"));

		var showAttackHealth = entity.attack != 0 || entity.health != 0;
		attack.gameObject.SetActive(showAttackHealth);
		health.gameObject.SetActive(showAttackHealth);
		attackCircle.SetActive(showAttackHealth);
		healthCircle.SetActive(showAttackHealth);

    }
}
