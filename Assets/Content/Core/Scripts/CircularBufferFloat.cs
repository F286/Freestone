using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class CircularBufferFloat : CircularBuffer<float>
{
  protected override float Add(float a, float b) {
		return a + b;
  }

  protected override float Multiply(float a, float b) {
		return a * b;
  }
}
