using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data {
	//public string name;
	public List<string> data;

	public List<Data> children;
}

public class DataHolder : MonoBehaviour {
	public static DataHolder instance;

    //[System.Serializable]
    //public class Minion
    //{
    //    public string name;
    //    public string cardName;
    //    public string cardText;
    //    public string cardArt;
    //    public int attack;
    //    public int health;
    //    public List<Event> events;
    //}

    //public List<Minion> minions;

    //public List<Hero> heroes;
    //public List<Card> cards;
    //public List<Minion> minions;

    public void Awake() {
        instance = this;
    }
	public Data data;

    public List<Entity> entities;

    public Entity getEntity(string name) {
        return entities.Find(_ => _.name == name);
    }
}
