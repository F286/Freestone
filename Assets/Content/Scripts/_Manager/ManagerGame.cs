using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour {
    //public Game game;

    public Event sequence;
    public List<Character> characters;

    public void OnEndTurn() {
        print("on end turn");
    }
}
