using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnchantmentData {
	public int attack;
	public int health;

	public EnchantmentData(int attack, int health) {
		this.attack = attack;
		this.health = health;
	}
}
public interface IEnchantment {
	// May need something to add forced ordering to
	// some enchantments, like enrage should always be last ect..
	EnchantmentData Evaluate(EnchantmentData data);
}
