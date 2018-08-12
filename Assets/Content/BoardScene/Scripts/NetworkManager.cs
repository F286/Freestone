using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class NetworkManager : UnityEngine.Networking.NetworkManager {

	public event Action<bool, MatchInfo> matchCreated;
	public event Action<bool, MatchInfo> matchJoined;
	private Action<bool, MatchInfo> NextMatchCreatedCallback;
	List<PlayerConnection> players;

	int iActivePlayer = 0;
	public int ActivePlayer {
		get {
			return iActivePlayer;
		}
	}

	public int GetPlayerIndex(PlayerConnection connection) {
		for (int i = 0; i < players.Count; i++) {
			if (connection == players[i]) {
				return i;
			}
		}
		return -1;
	}

	// [Space]
	// public GameObject card;

	// Use this for initialization
	void Start() {
		players = new List<PlayerConnection>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	// bool hasSpawnedCards = false;
	// Update is called once per frame
	void Update() {
		if (players.Count > 0) {
			CheckPlayersReady ();
		}
		// if (!hasSpawnedCards && 
		// 		players.Count == CardManager.instance.requiredForStart && 
		// 		CheckPlayersReady()) {
		// 	hasSpawnedCards = true;

		// 	int index = 0;
		// 	foreach (var item in players) {
		// 		SpawnCards(item, index);
		// 		index += 1;
		// 	}
		// }
	}
	// [Server]
	// public void SpawnCards(NetworkPlayer player, int index) {
	// 	print("spawn cards " + index);

	// 	for (int i = 0; i < 2; i++) {
	// 		var parent = CardManager.instance.hands[index];
	// 		print(parent);
	// 		var clone = GameObject.Instantiate(card, Vector2.zero, Quaternion.identity, parent);
	// 		// NetworkServer.Spawn(clone);
	// 		NetworkServer.SpawnWithClientAuthority(card, player.connectionToClient);
	// 		clone.GetComponent<Card>().RpcSetup(parent.gameObject);
	// 		// NetworkManager.Instantiate
	// 	}
	// }

	bool CheckPlayersReady() {
		bool playersReady = true;
		foreach (var player in players) {
			playersReady &= player.ready;
		}
		if (playersReady) {
			players[iActivePlayer].StartGame();
		}
		return playersReady;
	}

	public void ReTurn() {
		Debug.Log ("turn::"+iActivePlayer);
		players[iActivePlayer].TurnStart();
	}
	public void AlterTurns() {
		Debug.Log ("turn::"+iActivePlayer);

		players[iActivePlayer].TurnEnd();
		iActivePlayer = (iActivePlayer + 1) % players.Count;
		players[iActivePlayer].TurnStart();
	}
	public void UpdateScore(int score) {
		players [ActivePlayer].UpdateScore (score);
	}

	public void RegisterNetworkPlayer(PlayerConnection player) {
		if (players.Count <= 2) {
			// print("RegisterNetworkPlayer " + player.netId);
			// print(players.Count);

			// if (players.Find(p => p.playerIndex == 0) == null) {
			// 	player.playerIndex = 0;
			// }
			// else {
			// 	player.playerIndex = 1;
			// }
			// print(player.playerIndex);
			players.Add(player);

			// // Set Player Index
			// if (players.Find(p => p.playerIndex == 0) == null) {
			// 	player.playerIndex = 0;
			// }
			// else {
			// 	player.playerIndex = 1;
			// }
		}
	}

	public void DeregisterNetworkPlayer(PlayerConnection player) {
		players.Remove(player);
	}

	public void CreateOrJoin(string gameName, Action<bool, MatchInfo> onCreate) {
		StartMatchMaker();
		NextMatchCreatedCallback = onCreate;
		matchMaker.ListMatches(0, 10, "turnbasedgame", true, 0, 0, OnMatchList);
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if(scene.name == "GameScene") {
			NetworkServer.SpawnObjects();
		}
	}

	public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches) {
		Debug.Log("Matches:" + matches.Count);
		if (success && matches.Count > 0) {
			matchMaker.JoinMatch(matches[0].networkId, string.Empty, string.Empty, string.Empty, 0, 0, OnMatchJoined);
		}
		else {
			CreateMatch("turnbasedgame");
		}
	}

	public void CreateMatch(string matchName) {
		matchMaker.CreateMatch(matchName, 2, true, string.Empty, string.Empty, string.Empty, 0, 0, OnMatchCreate);
	}

	public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo) {
		base.OnMatchCreate(success, extendedInfo, matchInfo);
		Debug.Log("OnMatchCreate"+matchInfo.networkId);

		// Fire callback
		if (NextMatchCreatedCallback != null) {
			NextMatchCreatedCallback(success, matchInfo);
			NextMatchCreatedCallback = null;
		}

		// Fire event
		if (matchCreated != null) {
			matchCreated(success, matchInfo);
		}
	}

	public override void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo) {
		base.OnMatchJoined(success, extendedInfo, matchInfo);
		Debug.Log("OnMatchJoined"+matchInfo.networkId);

		// Fire callback
		if (NextMatchCreatedCallback != null) {
			NextMatchCreatedCallback(success, matchInfo);
			NextMatchCreatedCallback = null;
		}

		// Fire event
		if (matchJoined != null) {
			matchJoined(success, matchInfo);
		}
	}

	static NetworkManager _instance;
	public static NetworkManager instance {
		get {
			if (!_instance) {
				_instance = GameObject.FindObjectOfType<NetworkManager>();
			}
			return _instance;
		}
	}
}