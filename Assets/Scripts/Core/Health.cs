using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;
    bool isDead;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        print(healthPoints);
        if (healthPoints == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        if (isDead) return;

        isDead = true;
        // GetComponent<Animator>().SetTrigger("die");
        //        GetComponent<ActionScheduler>().CancelCurrentAction();
    }
}