using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth, poisonText;
    [SerializeField] private List<Weapon> availableWeapons;
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private List<GameObject> enemyImages;
    [SerializeField] private GameObject gameOverPanel;

    public Player player;

    private Enemy currentEnemy;
    private int currentEnemyIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    public static GameManager Instance { get; set; }

    void Start()
    {
        playerName.text = player.CharName;
        SpawnEnemy();
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = currentEnemy.health.ToString();
    }

    public void DoRound()
    {
        Debug.Log("NEW ROUND");
        
        UpdateEnemyImage();
        
        if (player.Weapon is PoisonWeapon poisonWeapon)
        {
            poisonWeapon.ApplyPoison();
        }
        
        if (currentEnemy is Wizard wizard)
        {
            wizard.CheckHealing();
        }
        
        currentEnemy.GetHit(player.Weapon);
        player.Weapon.ApplyEffect(currentEnemy);
        
        int enemyDamage = currentEnemy.Attack();
        player.GetHit(enemyDamage);
        currentEnemy.Weapon.ApplyEffect(player);
        
        UpdateHealth();

        if (currentEnemy.health <= 0)
        {
            ChangeEnemy();
        }
    }
    
    public void SelectWeapon(int index)
    {
        if (index >= 0 && index < availableWeapons.Count)
            player.Weapon = availableWeapons[index];
        Debug.Log("Equipped weapon: " + player.Weapon.name);
    }

    public void GameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowPoisonText(bool show)
    {
        if (poisonText != null)
        {
            poisonText.text = show ? "Poisoned" : "";
        }
    }
    
    public void SpawnEnemy()
    {
        foreach (Enemy enemy in enemyList)
        {
            enemy.gameObject.SetActive(false);
        }
        
        foreach (GameObject enemyImage in enemyImages)
        {
            enemyImage.SetActive(false);
        }

        currentEnemy = enemyList[currentEnemyIndex];
        currentEnemy.gameObject.SetActive(true);
        enemyImages[currentEnemyIndex].SetActive(true);
        
        enemyName.text = currentEnemy.name;
        enemyHealth.text = currentEnemy.health.ToString();
    }

    public void ChangeEnemy()
    {
        currentEnemy.gameObject.SetActive(false);
        currentEnemyIndex = (currentEnemyIndex + 1) % enemyList.Count;
        SpawnEnemy();
    }
    
    private void UpdateEnemyImage()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyImages[i].SetActive(i == currentEnemyIndex);
        }
    }
}
