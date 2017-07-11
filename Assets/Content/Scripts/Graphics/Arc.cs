using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour {
    public Vector2 start = new Vector2(-1, 0);
    public Vector2 end = new Vector2(1, 0);

    public Vector2 evaluate(float t) {
        return Vector2.Lerp(transform.TransformPoint(start), transform.TransformPoint(end), t);
    }

	void OnDrawGizmos()
	{
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.TransformPoint(start), transform.TransformPoint(end));
	}
}
