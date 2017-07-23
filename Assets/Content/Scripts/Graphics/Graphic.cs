using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Graphic : MonoBehaviour, IOnTouch {
	public GameObject source;
	public TextMesh attack;
	public TextMesh health;

	public SpriteRenderer art;
	public SpriteMask artMask;

    public void OnTouch(GestureState state)
	{
        //print(state.phase);
		ManagerGame.instance.DragCard(state, this);
    }
	public virtual void UpdateGraphics(EntityData entity) {
		attack.text = Format(entity.attack.ToString());
		health.text = Format(entity.health.ToString());

		art.sprite = Resources.Load<Sprite>(entity.Get("art"));

		art.transform.localScale = Vector3.one;
		var scale = new Vector2(artMask.bounds.size.x / art.bounds.size.x, 
		                        artMask.bounds.size.y / art.bounds.size.y);
		//print(scale);
		var s = Mathf.Max(scale.x, scale.y);
		art.transform.localScale = new Vector3(s, s, 1);
	}

	public static string Format(string text) {
		return "<b>" + text.Replace('/', '\n') + "</b>";
	}
}
