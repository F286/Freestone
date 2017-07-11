using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    Minion,
    Spell,
    Draw,
    TurnBegin,
    TurnEnd,
    //None,

	//PlayMinion,
	//PlaySpell,
    //Damage,

	//DamageMinion,
	//DamageCharacter,
 //   HealMinion,
 //   HealCharacter,
	//DrawCard,
	//TurnBegin,
	//TurnEnd,
    //Damage,
    //Heal,
    //SummonMinion,
    //DrawCard,
}
public enum EventTarget
{
    None,
    Minion,
    Character,
    Board,
    //Random,
}

[System.Serializable]
public class Event {
    public string name = "test_0";
    public EventType type;
    //public string data;
    public EventTarget target;

    public void evaluate(ManagerGame game)
    {
        //switch (type)
        //{
        //    case EventType.PlayMinion:
        //        break;
        //    case EventType.PlaySpell:
        //        break;
        //    case EventType.DamageMinion:
        //        break;
        //    default:
        //        Debug.LogError("Event.cs, event type not implemented.");
        //        break;
        //}
    }
}
