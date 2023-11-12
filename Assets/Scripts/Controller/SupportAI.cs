using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportAI : MonoBehaviour
{
    public AriSO ariSO;

    private GameObject playerBase;
    [SerializeField] private Animator animator;

    [SerializeField] float healAmount = 10f;
    [SerializeField] int regenAmount = 3;
    [SerializeField] float healCooldown = 8f;

    float timeSinceLastHeal = Mathf.Infinity;
    private bool isLeft;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerBase = GameObject.FindWithTag("PlayerBase");
    }

    void Update()
    {
        if (ariSO != null)
        {
            healAmount = ariSO.heal;
            regenAmount = ariSO.regen;
            healCooldown = ariSO.healCooldown;

        }
        // if (playerBase.GetComponent<Health>().IsDead()) return;

        timeSinceLastHeal += Time.deltaTime;

        if (animator != null) SetDirection();

        if (!playerBase.GetComponent<Health>().IsMaxHealth())
        {
            StartCoroutine(HealBehaviour());
        }


    }

    private void SetDirection()
    {
        if (playerBase.transform.position.x < transform.position.x)
        {
            animator.SetBool("IsLeft", true);
        }

        else if (playerBase.transform.position.x > transform.position.x)
        {
            animator.SetBool("IsLeft", false);
        }
    }

    private IEnumerator HealBehaviour()
    {
        if (timeSinceLastHeal > healCooldown)
        {
            for (int i = 0; i < regenAmount; i++)
            {
                animator.SetTrigger("IsBuilding");
                playerBase.GetComponent<Health>().TakeHeal(healAmount);
                TextPopup.CreateHeal(playerBase.transform.position, (int)healAmount);
                timeSinceLastHeal = 0;
                yield return new WaitForSeconds(1f);
            }

            timeSinceLastHeal = 0;
        }
    }
}
