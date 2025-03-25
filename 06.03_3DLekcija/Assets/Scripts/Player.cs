using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;

    public string CharName
    {
        get { return charName; }
    }

    // iespeja izveleties starp ierociem
    public new Weapon Weapon
    {
        get { return weapon; }
        set
        {
            weapon = value;
        }
    }
}
