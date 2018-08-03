using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Intent : MonoBehaviour {

	public abstract IntentType intentType {
		get;
	}
	
}
