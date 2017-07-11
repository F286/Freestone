using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnClick {
    void OnClick();
}
public class InputManager : MonoBehaviour {
    public void Awake() {
        Input.simulateMouseWithTouches = true;
    }
    public void Update () {
        if (Input.GetMouseButtonDown(0)) {
            var overlap = Physics2D.OverlapCircle(
                Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.3f);
            if (overlap != null) {
	            overlap.gameObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
	        }
        }
	}
}
