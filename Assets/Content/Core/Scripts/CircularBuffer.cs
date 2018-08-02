using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public abstract class CircularBuffer<T> where T : new() {
	public T[] values = new T[3];
	public int current;

	int lastFrameCount = 0;
	/// <summary> Pushes value with validation to not add duplicate values for same frame, and padding for missed frames </summary>
	public void PushAtCurrentFrame(T value) {
		if (lastFrameCount != 0) {
			if (lastFrameCount >= Time.frameCount) {
				return;
			}
			for (int i = 0; i < Mathf.Min(values.Length, Time.frameCount - lastFrameCount - 1); i++) {
				Push(default(T));
			}
		}
		Push(value);

		lastFrameCount = Time.frameCount;
	}
	public void Push(T value) {
		Assert.AreNotEqual(values.Length, 0, "CircularBuffer values.Length cannot be 0.");

		values[current % values.Length] = value;
		current++;
	}
	public T Average() {
		var sum = new T();
		var length = Mathf.Min(current, values.Length);

		for (int i = 0; i < length; i++) {
			sum = Add(sum, values[i]);
		}
		return length == 0 ? sum : Multiply(sum, (1f / length));
	}
  public void Clear() {
		lastFrameCount = 0;
		for (int i = 0; i < values.Length; i++) {
			values[i] = new T();
		}
		current = 0;
  }
	protected abstract T Add(T a, T b);
	protected abstract T Multiply(T a, float b);
}
