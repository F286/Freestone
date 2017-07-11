using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    None,
	PlayMinion,
	PlaySpell,
	DamageMinion,
	DamageCharacter,
    HealMinion,
    HealCharacter,
	DrawCard,
	TurnBegin,
	TurnEnd,
    //Damage,
    //Heal,
    //SummonMinion,
    //DrawCard,
}
//public enum EventTarget
//{
//    None,
//    Minion,
//    Character,
//    Random,
//}

[System.Serializable]
public class Event {
    //public string name = "event name";
    public EventType type;
    public string data;
    //public EventTarget target;

    public void evaluate(ManagerGame game)
    {
        switch (type)
        {
            case EventType.PlayMinion:
                break;
            case EventType.PlaySpell:
                break;
            case EventType.DamageMinion:
                break;
            default:
                Debug.LogError("Event.cs, event type not implemented.");
                break;
        }
    }
}
