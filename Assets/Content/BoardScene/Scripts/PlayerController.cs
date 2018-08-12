using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// public PlayerEvent onIntent;
	bool isLocalPlayer = false;

	// public void OnEnable() {
	// 	CardManager.instance.onIntent.AddListener(Intent);
	// }
	// public void OnDisable() {
	// 	CardManager.instance.onIntent.RemoveListener(Intent);
	// }
	// void Intent(IntentType action, string from, string to) {
	// 	onIntent.Invoke(action, from, to);
	// }

	// public void Execute(IntentType action, string from, string to) {
	// 	// CardManager.instance.Execute(action, from, to);
	// 	CardManager.instance.onExecute.Invoke(action, from, to);
	// }

	// Update is called once per frame
	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		Shoot ();
	}

	public void SetupLocalPlayer()
	{
		//add color to your player
		isLocalPlayer = true;

		// instance = this;
	}

	public void TurnStart()
	{
		if (isLocalPlayer)
		{
			//spawn or enable player
		}
	}

	public void TurnEnd()
	{
		if (isLocalPlayer)
		{
			// unspawn or disable player
		}
	}

	// public void SendPlayerInput(PlayerAction action, string from, string to) {

	// }

	public void Shoot()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		int power = 50;

		// if (Application.platform == RuntimePlatform.Android)
		// {
		// 	Touch touch = Input.GetTouch(0);
		// 	if (touch.phase == TouchPhase.Began)
		// 	{
		// 		OnPlayerInput(PlayerAction.SHOOT, power);
		// 	}
		// }
		// else
		// {
		// 	if (Input.GetMouseButtonDown (0))
		// 	{
		// 		OnPlayerInput(PlayerAction.SHOOT, power);
		// 	}
		// }
	}
}