using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	public void Start() {
		print(this.isLocalPlayer);
	}
}
