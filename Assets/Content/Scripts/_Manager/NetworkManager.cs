using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : NetworkBehaviour {
	public void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			CmdSpawn();
		}
	}

	[Command]
	void CmdSpawn() {
		var load = Resources.Load<NETWORK_EndTurn>("Network End Turn");
		var create = Instantiate(load, transform);
		create.test = "hello 123";
		NetworkServer.Spawn(create.gameObject);
	}
}
