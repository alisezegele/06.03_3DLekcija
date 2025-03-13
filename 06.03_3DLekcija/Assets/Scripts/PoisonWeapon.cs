using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private int poisonStrength = 3;
    
    public override void ApplyEffect(Character target)
    {
        Debug.Log(target.name + " poisoned for " + poisonStrength);
        target.GetHit(poisonStrength);
    }
}
