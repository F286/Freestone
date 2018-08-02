using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class CircularBufferVector2 : CircularBuffer<Vector2>
{
  protected override Vector2 Add(Vector2 a, Vector2 b) {
		return a + b;
  }

  protected override Vector2 Multiply(Vector2 a, float b) {
		return a * b;
  }
}
