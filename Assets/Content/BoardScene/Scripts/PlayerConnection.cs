using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;

public class PlayerConnection : NetworkBehaviour {

	[SyncVar(hook = "OnTurnChange")]
	public bool isTurn = false;

	[SyncVar(hook = "UpdateTimeDisplay")]
	public float time = 100;

	// [SyncVar(hook = "SetPlayerIndex")]
	// public int playerIndex = -1;

	public PlayerController controller;

	[SyncVar]
	public bool ready = false;

	// [Space]
	// public GameObject card;

	// public void SetPlayerIndex(int index) {
	// 	// CmdSpawnCards(index);
	// }
	// [Command]
	// public void CmdSpawnCards(int index) {
	// 	for (int i = 0; i < 3; i++) {
	// 		var parent = CardManager.instance.hands[index];
	// 		var clone = GameObject.Instantiate(card, Vector2.zero, Quaternion.identity, parent);
	// 		NetworkServer.Spawn(clone);
	// 		// NetworkManager.Instantiate
	// 	}
	// }
	// public void Start() {
	// 	if (isLocalPlayer) {
	// 		// print(playerControllerId);
	// 		CmdSpawnCards();
	// 	}
	// }
	// public void SetPlayerIndex(int index) {
	// 	print(index);
	// 	print(isLocalPlayer);
	// 	if (isLocalPlayer) {
	// 		CmdSpawnCards(index);
	// 	}
	// }
	public override void OnStartAuthority() {
		// if (isLocalPlayer) {
			print("start authority");
			CmdSpawnCards();
		// }
	}
	[Command]
	public void CmdSpawnCards() {
		print("cmd spawn cards");
		for (int i = 0; i < 2; i++) {
			// var parent = CardManager.instance.hands[index];
			// print(parent);
			var clone = GameObject.Instantiate(CardManager.instance.cardTemplate);
			NetworkServer.SpawnWithClientAuthority(clone, connectionToClient);
			var index = NetworkManager.instance.GetPlayerIndex(this);
			// print(index);
			clone.GetComponent<Card>().parent = CardManager.instance.hands[index].name;
			// RpcParentCard(clone, index);
		}
	}
	// [ClientRpc]
	// public void RpcParentCard(GameObject card, int playerIndex) {
	// 	print("rpc parent card " + playerIndex);
	// 	card.transform.SetParent(CardManager.instance.hands[playerIndex], false);
	// }
	// public void SpawnCards(NetworkPlayer player, int index) {
	// 	print("spawn cards " + index);

	// 	for (int i = 0; i < 2; i++) {
	// 		var parent = CardManager.instance.hands[index];
	// 		print(parent);
	// 		var clone = GameObject.Instantiate(card, Vector2.zero, Quaternion.identity, parent);
	// 		NetworkServer.Spawn(clone);
	// 		// NetworkServer.SpawnWithClientAuthority(card, player.connectionToClient);
	// 		// clone.GetComponent<Card>().RpcSetup(parent.gameObject);
	// 		// NetworkManager.Instantiate
	// 	}
	// }

	// Update is called once per frame
	[Server]
	void Update() {
		if (isTurn) {
			time -= Time.deltaTime;
			if (time <= 0) {
				NetworkManager.instance.AlterTurns();
			}
		}
	}

	public override void OnStartClient() {
		DontDestroyOnLoad(this);

		base.OnStartClient();
		// Debug.Log("Client Network Player start");
		StartPlayer();

		NetworkManager.instance.RegisterNetworkPlayer(this);
	}

	public override void OnStartLocalPlayer() {
		base.OnStartLocalPlayer();
		controller.SetupLocalPlayer();
	}

	[Server]
	public void StartPlayer() {
		ready = true;
	}

	public void StartGame() {
		// SpawnCards(playerIndex);
		TurnStart();
	}
	// [Server]
	// public void SpawnCards(int index) {
	// 	print("spawn cards " + index);

	// 	for (int i = 0; i < 2; i++) {
	// 		var parent = CardManager.instance.hands[index];
	// 		print(parent);
	// 		var clone = GameObject.Instantiate(card, Vector2.zero, Quaternion.identity, parent);
	// 		// NetworkServer.Spawn(clone);
	// 		NetworkServer.SpawnWithClientAuthority(card, )
	// 		clone.GetComponent<Card>().RpcSetup(parent.gameObject);
	// 		// NetworkManager.Instantiate
	// 	}
	// }

	[Server]
	public void TurnStart() {
		isTurn = true;
		time = 90;
		RpcTurnStart();
	}
	[ClientRpc]
	void RpcTurnStart() {
		controller.TurnStart();
	}
	[Server]
	public void TurnEnd() {
		isTurn = false;
		RpcTurnEnd();
	}
	[ClientRpc]
	void RpcTurnEnd() {
		controller.TurnEnd();
	}

	public override void OnNetworkDestroy() {
		base.OnNetworkDestroy();
		if (NetworkManager.instance) {
			NetworkManager.instance.DeregisterNetworkPlayer(this);
		}
	}

	public void OnTurnChange(bool turn) {
		if (isLocalPlayer) {
			//play turn sound 
		}
	}
	public void UpdateScore(int score) {
		Debug.Log ("score:"+score);
	}
	public void UpdateTimeDisplay(float curtime) {
		GameObject timerText = GameObject.FindWithTag("Timer");
		Text timer = timerText.GetComponent<Text> ();
		timer.text = Mathf.Round(curtime).ToString();
	}
}