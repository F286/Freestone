using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Core {

	public static string GameObjectToPath(GameObject gameObject) {
		return gameObject.transform.parent.parent.name + "/" +
			   gameObject.transform.parent.name + "/" +
			   gameObject.transform.name;
	}
	public static EntityData PathToEntity(string path) {
		return ManagerGame.instance.game.transform.Find(path).gameObject.GetComponent<EntityData>();
	}
	public static Graphic PathToGraphic(string path) {
		return ManagerGame.instance.graphics.transform.Find(path).gameObject.GetComponent<Graphic>();
	}
	//public static GameObject PathToGameObjectGraphics(string path) {
	//	return ManagerGame.instance.graphics.transform.Find(path).gameObject;
	//}

	public static T AddEnchantment<T>(this EntityData data) where T : MonoBehaviour, IEnchantment {
		var g = new GameObject(typeof(T).ToString());
		g.transform.parent = data.transform;
		var b = g.AddComponent<T>();
		return b;
	}

	public static string Format(string text) {
		return "<b>" + text.Replace('%', '\n') + "</b>";
	}
}
