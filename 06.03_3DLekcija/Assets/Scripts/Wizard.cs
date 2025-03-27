using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    private float healChance = 0.3f;
    private int minHealAmount = 8;
    private int maxHealAmount = 15;

    public void Heal()
    {
        int healAmount = Random.Range(minHealAmount, maxHealAmount + 1);
        Health += healAmount;
        Debug.Log(name + " heals for " + healAmount + " health");
    }
    public void CheckHealing()
    {
        if (Random.Range(0f, 1f) <= healChance)
        {
            Heal();
        }
    }
}