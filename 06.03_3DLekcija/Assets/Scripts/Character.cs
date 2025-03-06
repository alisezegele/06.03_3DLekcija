using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;

    public void Shout()
    {
        Debug.Log("I AM " + name);
    }
}
