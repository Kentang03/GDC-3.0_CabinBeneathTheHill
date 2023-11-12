using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportAI : MonoBehaviour
{
    private GameObject target;
    [SerializeField] float healAmount = 10f;
    [SerializeField] int regenAmount = 3;
    [SerializeField] float healCooldown = 8f;

    float timeSinceLastHeal = Mathf.Infinity;

    void Start() {
        target = GameObject.FindWithTag("PlayerBase");
    }

    void Update() {
        if (target.GetComponent<Health>().IsDead()) return;

        timeSinceLastHeal += Time.deltaTime;
        
        if (!target.GetComponent<Health>().IsMaxHealth())
        {
            StartCoroutine(HealBehaviour());
        }
    }

    private IEnumerator HealBehaviour()
    {
        if (timeSinceLastHeal > healCooldown)
        {
            for (int i = 0; i < regenAmount; i++)
            {
                target.GetComponent<Health>().TakeHeal(healAmount);
                TextPopup.CreateHeal(target.transform.position, (int)healAmount);
                timeSinceLastHeal = 0;
                yield return new WaitForSeconds (1f);

            }
        }
    }
}
