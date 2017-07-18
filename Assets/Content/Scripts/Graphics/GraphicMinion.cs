using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicMinion : Graphic {
	public TextMesh attack;
	public TextMesh health;

    public SpriteRenderer art;

    public override void UpdateGraphics(EntityData entity) {
		attack.text = Format(entity.Get("attack"));
		health.text = Format(entity.Get("health"));

        art.sprite = Resources.Load<Sprite>(entity.Get("art"));
    }
}
