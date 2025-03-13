using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Enemy
{
    [SerializeField] private int aggressionGain = 10;
    public override int Attack()
    {
        aggression += aggressionGain;
        return Weapon.GetDamage() + aggression / 10;
    }
}
