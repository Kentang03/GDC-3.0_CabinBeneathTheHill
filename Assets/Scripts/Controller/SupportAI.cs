using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportAI : MonoBehaviour
{
    private GameObject target;
    [SerializeField] float healAmount = 10f;
    [SerializeField] float healCooldown = 8f;

    float timeSinceLastHeal = Mathf.Infinity;

    void Start() {
        target = GameObject.FindWithTag("PlayerBase");
    }

    void Update() {
        timeSinceLastHeal += Time.deltaTime;
        
        if (!target.GetComponent<Health>().IsMaxHealth())
        {
            HealBehaviour();
        }
    }

    private void HealBehaviour()
    {
        if (timeSinceLastHeal > healCooldown)
        {
            target.GetComponent<Health>().TakeHeal(healAmount);
            TextPopup.CreateHeal(target.transform.position, (int)healAmount);
            timeSinceLastHeal = 0;
        }
    }
}
