using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    private float healChance = 0.3f; // 30% chance to heal
    private int minHealAmount = 8;
    private int maxHealAmount = 15;

    // Method to heal the wizard
    public void Heal()
    {
        int healAmount = Random.Range(minHealAmount, maxHealAmount + 1);  // Random heal amount between 8 and 15
        Health += healAmount;
        Debug.Log(name + " heals for " + healAmount + " health!");
    }

    // Method to check if the wizard should heal
    public void CheckHealing()
    {
        // 30% chance to heal
        if (Random.Range(0f, 1f) <= healChance)
        {
            Heal();  // Heal the wizard if the chance is met
        }
    }
}