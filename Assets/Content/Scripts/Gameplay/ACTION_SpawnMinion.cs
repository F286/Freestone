using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_SpawnMinion : MonoBehaviour, IAction {
	public string minionName;
	public static int index;
	public void OnEvent() {
		var entity = ManagerData.instance.GetEntity(minionName);
		var g = Instantiate(entity, transform.parent);
		g.name = minionName + index;
		g.transform.SetSiblingIndex(transform.GetSiblingIndex());

		index++;
	}
}
