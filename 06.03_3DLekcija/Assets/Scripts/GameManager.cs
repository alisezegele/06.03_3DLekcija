using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Character character;
    
    void Start()
    {
        player.Shout();
        Debug.Log("player name: " + player.CharName);
        enemy.Shout();
        character.Shout();
    }
}
