using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour {
  public bool isActive;
  
  internal void SetState(bool isActive) {
    this.isActive = isActive;

    gameObject.SetActive(isActive);

    OnSetState(isActive);

    if(isActive) {
      OnEnter();
    }
    else {
      OnExit();
    }
  }
  public virtual void OnSetState(bool isActive) {
  }
  public virtual void OnEnter() {
  }
  public virtual void OnExit() {
  }
}

[System.Serializable]
public class StateMachine {
  public State current;

  public void Set(State target) {
    if(current != null) {
      current.SetState(false);
    }

    current = target;

    if(current != null) {
      current.SetState(true);
    }
  }
}