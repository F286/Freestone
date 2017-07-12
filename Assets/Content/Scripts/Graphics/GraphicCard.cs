using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicCard : Graphic, IOnClick {
	public void OnClick()
	{
		ManagerGame.instance.TakeAction(this);
	}
}
