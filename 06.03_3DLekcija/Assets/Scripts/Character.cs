using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    
    [SerializeField] private Weapon weapon;

    public Weapon Weapon
    {
        get { return weapon; }
    }

    public int Attack()
    {
        return weapon.GetDamage();
    }

    public void GetHit(int damage)
    {
        Debug.Log(name + " starting health: " + health);
        health -= damage;
        Debug.Log("health after hit: " + health);
    }
}
