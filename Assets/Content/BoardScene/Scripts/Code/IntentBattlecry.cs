using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentBattlecry : Intent {

  public override IntentType intentType {
    get {
			return IntentType.Battlecry;
    }
  }

	public CardEvent onSelectTarget;

}
