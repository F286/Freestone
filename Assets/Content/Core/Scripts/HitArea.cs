using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class HitArea : UnityEngine.UI.Graphic {
  protected override void OnPopulateMesh(VertexHelper vh) {
    vh.Clear();
  }

#if UNITY_EDITOR
  protected override void Reset() {
    base.Reset();
    
    if (gameObject.name == "GameObject") {
      gameObject.name = "Hit Area";
    }
  }
#endif
}