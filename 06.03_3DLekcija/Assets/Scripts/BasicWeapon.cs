using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : Weapon
{
    public override void ApplyEffect(Character target)
    {
        Debug.Log("No additional effect");
    }
}
