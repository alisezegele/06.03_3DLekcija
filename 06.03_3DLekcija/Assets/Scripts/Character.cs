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

    public virtual void GetHit(int damage)
    {
        Debug.Log(name + "'s starting health: " + health);
        Health -= damage;
        Debug.Log("Damage taken: " + damage + ". "+ name + "'s health is now: " + health);
    }

    public void GetHit(Weapon weapon)
    {
        Debug.Log(name + "'s starting health: " + health);
        health -= weapon.GetDamage();
        Debug.Log(weapon.name + " does " + weapon.GetDamage() + " damage. " + name + "'s health after hit by "+ weapon.name + ": " + health);
    }

    private void Die()
    {
        Debug.Log(name + " died!");
        GameManager.Instance.GameOverScreen();
    }
}
