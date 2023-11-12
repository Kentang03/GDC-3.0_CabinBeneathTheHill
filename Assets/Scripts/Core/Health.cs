using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealthPoints = 100f;
    [SerializeField] float healthPoints = 100f;
    bool isDead;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        if (healthPoints == 0)
        {
            Die();
        }
    }

    public void TakeHeal(float heal)
    {
        healthPoints += heal;
        if (healthPoints > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }
    }

    public bool IsMaxHealth()
    {
        return healthPoints == maxHealthPoints;
    }

    public float GetMaxHealthPoints()
    {
        return maxHealthPoints;
    }
    
    public float GetHealthPoints()
    {
        return healthPoints;
    }

    private void Die()
    {
        if (isDead) return;
        // Destroy(gameObject);
        isDead = true;
        // GetComponent<Animator>().SetTrigger("die");
        //        GetComponent<ActionScheduler>().CancelCurrentAction();
    }
}