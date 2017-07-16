using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_SpawnMinion : MonoBehaviour, IAction {
	public string minionName;
	public static int index;
	public void OnEvent() {
		var n = minionName == "" ? name : minionName;
		var entity = ManagerData.instance.GetEntity(n);
		var g = Instantiate(entity, transform.parent);
		g.name = n + index;
		g.transform.SetSiblingIndex(transform.GetSiblingIndex());

		index++;
	}
}
