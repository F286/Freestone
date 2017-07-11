using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    Damage,
    Heal,
    SummonMinion,
}
public enum EventTarget
{
    Minion,
    Character,
    Random,
}

[System.Serializable]
public class Event {
    public string name = "event name";
    public EventType type;
    public string data;
    public EventTarget target;

    public void evaluate(ManagerGame game)
    {
        switch (type)
        {
            case EventType.Damage:
                break;
            case EventType.Heal:
                break;
            case EventType.SummonMinion:
                break;
        }
    }
}
