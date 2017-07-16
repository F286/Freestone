using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTION_SpawnMinion : MonoBehaviour, IAction {
	public string minionName;
	public void OnEvent() {
		var entity = ManagerData.instance.GetEntity(minionName);
		var g = Instantiate(entity, transform.parent);
		g.name = entity.name;
		g.transform.SetSiblingIndex(transform.GetSiblingIndex());
	}
}
