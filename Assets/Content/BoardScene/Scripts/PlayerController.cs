using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAction
{
	Drag,
	Press,
	// SHOOT,
	// JUMP
}

public class PlayerController : MonoBehaviour
{
	// public delegate void PlayerInputCallback(PlayerAction action, string from, string to);
	// public event PlayerInputCallback OnPlayerInput;
	public PlayerEvent onInput;
	bool isLocalPlayer = false;

	// public static PlayerController instance;

	// Use this for initialization
	// void Start()
	// {
	// }

	public void OnEnable() {
		CardManager.instance.onInput.AddListener(InputEvent);
	}
	public void OnDisable() {
		CardManager.instance.onInput.RemoveListener(InputEvent);
	}
	void InputEvent(PlayerAction action, string from, string to) {
		print("input " + from);
		onInput.Invoke(action, from, to);
		// Debug.Log(this, this);
	}

	public void ExecuteEvent(PlayerAction action, string from, string to) {
		print("execute " + from);
		CardManager.instance.ExecuteEvent(action, from, to);
	}

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