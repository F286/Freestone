using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicMinion : Graphic, IOnClick {
	public void OnClick() {
        ManagerGame.instance.TakeAction(index);
    }
}
