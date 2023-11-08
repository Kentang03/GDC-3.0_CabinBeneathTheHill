using UnityEngine;

class AIController : MonoBehaviour 
{
    private Fighter fighter;
    private Health health;
    private GameObject playerBase;
    private Mover mover;

    private void Start()
    {
        fighter = GetComponent<Fighter>();
        health = GetComponent<Health>();
        mover = GetComponent<Mover>();
        playerBase = GameObject.FindWithTag("PlayerBase");

        fighter.Attack(playerBase);
    }

    private void Update()
    {
        if (health.IsDead()) return;

    }
  
}