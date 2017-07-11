using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IOnClick
{
    public GameObject target;
    public string methodName;

    public void OnClick()
    {
        target.SendMessage(methodName);
    }
}
