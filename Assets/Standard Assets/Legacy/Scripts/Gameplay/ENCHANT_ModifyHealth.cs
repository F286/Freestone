using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENCHANT_ModifyHealth : MonoBehaviour, IEnchantment {
	public int amount = -1;
	public EnchantmentData Evaluate(EnchantmentData data) {
		data.health += amount;
		return data;
	}
}
