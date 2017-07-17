using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Core {

	public static string GameObjectToPath(GameObject gameObject) {
		return gameObject.transform.parent.parent.name + "/" +
			   gameObject.transform.parent.name + "/" +
			   gameObject.transform.name;
	}
	public static GameObject PathToGameObjectGame(string path) {
		return ManagerGame.instance.game.transform.Find(path).gameObject;
	}
	public static GameObject PathToGameObjectGraphics(string path) {
		return ManagerGame.instance.graphics.transform.Find(path).gameObject;
	}
}
