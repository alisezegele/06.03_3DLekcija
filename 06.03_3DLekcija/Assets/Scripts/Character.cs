using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    
    public Weapon weapon;

    public Weapon Weapon
    {
        get { return weapon; }
    }

    public virtual int Attack()
    {
        return weapon.GetDamage();
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = Mathf.Max(value, 0);

            if (health == 0)
            {
                Die();
            }
        }
    }

    public void GetHit(int damage)
    {
        Debug.Log(name + " starting health: " + health);
        Health -= damage;
    }

    public void GetHit(Weapon weapon)
    {
        Debug.Log(name + " starting health: " + health);
        health -= weapon.GetDamage();
        Debug.Log("health after hit by "+ weapon.name + ": " + health);
    }

    public void Die()
    {
        Debug.Log(name + " died!");
        GameManager.Instance.GameOverScreen();
    }
}
