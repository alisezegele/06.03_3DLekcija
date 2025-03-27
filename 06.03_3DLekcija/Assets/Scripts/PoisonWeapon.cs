using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonWeapon : Weapon
{
    [SerializeField] private int poisonStrength = 3, poisonDuration = 2;
    [SerializeField] private float poisonChance = 0.3f; // 30%, ka enemy tiks poisoned

    private int remainingPoisonRounds = 0;
    private Character poisonedTarget;
    
    public override void ApplyEffect(Character target)
    {
        if (IsPoisoned())
        {
            Debug.Log(target.name + " is already poisoned.");
            return;
        }
        
        if (Random.value < poisonChance)
        {
            Debug.Log(target.name + " poisoned for " + poisonStrength + " for " + poisonDuration + " rounds");
            poisonedTarget = target;
            remainingPoisonRounds = poisonDuration;
            
            FindObjectOfType<GameManager>()?.ShowPoisonText(true);
        }
        else
        {
            Debug.Log(target.name + " didn't get poisoned");
        }
    }

    public void ApplyPoison()
    {
        if (poisonedTarget != null && remainingPoisonRounds > 0)
        {
            poisonedTarget.GetHit(poisonStrength);
            Debug.Log(poisonedTarget.name + " poisoned for " + poisonStrength + "damage");
            remainingPoisonRounds--;

            if (remainingPoisonRounds <= 0)
            {
                Debug.Log(poisonedTarget.name + " is no longer poisoned");
                poisonedTarget = null;
                
                FindObjectOfType<GameManager>()?.ShowPoisonText(false);
            }
        }
    }
    public bool IsPoisoned()
    {
        return poisonedTarget != null && remainingPoisonRounds > 0;
    }
}
