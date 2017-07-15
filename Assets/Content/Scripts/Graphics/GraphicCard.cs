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
		manaCost.text = 	Format(entity.Get("mana_cost") 	);
		attack.text = 		Format(entity.Get("attack") 	);
		health.text = 		Format(entity.Get("health")		);
		title.text = 		Format(entity.Get("title") 		);
		description.text = 	Format(entity.Get("description"));
	}
}
