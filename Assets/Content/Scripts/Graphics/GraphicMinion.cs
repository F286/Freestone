using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicMinion : Graphic {

    public SpriteRenderer art;

	public override void UpdateGraphics(EntityData entity) {
		base.UpdateGraphics(entity);

		art.sprite = Resources.Load<Sprite>(entity.Get("art"));
    }
}
