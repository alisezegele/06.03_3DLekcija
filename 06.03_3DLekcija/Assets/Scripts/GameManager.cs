using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth;
    [SerializeField] private List<Weapon> availableWeapons;
    [SerializeField] private GameObject gameOverPanel;
    
    public static GameManager instance;
    public Player player;
    public Enemy enemy;

    void Awake()
    {
        Instance = this;
    }

    public static GameManager Instance { get; set; }

    void Start()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = enemy.health.ToString();
    }

    public void DoRound()
    {
        //int damage = player.Attack();
        enemy.GetHit(player.Weapon);
        player.Weapon.ApplyEffect(enemy);
        int enemyDamage = enemy.Attack();
        player.GetHit(enemyDamage);
        enemy.Weapon.ApplyEffect(player);
        UpdateHealth();
    }
    
    public void SelectWeapon(int index)
    {
        if (index >= 0 && index < availableWeapons.Count)
            player.Weapon = availableWeapons[index];
        Debug.Log("equipped weapon: " + player.Weapon.name);
    }

    public void GameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
