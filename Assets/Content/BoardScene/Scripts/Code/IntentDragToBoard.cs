using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentDragToBoard : Intent {

  public override IntentType intentType {
    get {
			return IntentType.DragToBoard;
    }
  }

	public CardEvent onDragToBoard;

}
