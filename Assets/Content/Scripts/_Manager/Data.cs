using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
	public static Data instance;

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

    public List<Entity> entities;

    public Entity getEntity(string name) {
        return entities.Find(_ => _.name == name);
    }
}
